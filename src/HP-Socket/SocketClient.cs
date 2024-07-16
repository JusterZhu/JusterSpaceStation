using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using HPSocketCS;
using X.NetCore.Events;
using X.NetCore.Packet;
using X.NetCore.Utils;

[assembly: InternalsVisibleTo("X")]
[assembly: InternalsVisibleTo("X.IM")]
[assembly: InternalsVisibleTo("X.LOL")]
[assembly: InternalsVisibleTo("X.Domain")]
[assembly: InternalsVisibleTo("X.Club")]
[assembly: InternalsVisibleTo("X.Race")]
[assembly: InternalsVisibleTo("X.LOLReferee")]
[assembly: InternalsVisibleTo("X.SignIn")]
namespace X.NetCore
{
    internal class SocketClient: TcpClient
    {
        #region Private Members
        private const int PeriodTime = 500;

        private int _seqId;
        private readonly int _millisecondsSendTimeout;
        private readonly int _millisecondsReceiveTimeout;

        private Timer _timer;
        private readonly PendingSendQueue _pendingQueue;
        private readonly ReceivingQueue _receivingQueue;   
        private readonly PacketParser _parser = new PacketParser();

        private static SocketClient _defaultInstance;

        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int description, int reservedValue);
        #endregion

        #region Constructors
        public SocketClient(int millisecondsSendTimeout, int millisecondsReceiveTimeout)
        {
            _millisecondsSendTimeout = millisecondsSendTimeout;
            _millisecondsReceiveTimeout = millisecondsReceiveTimeout;

            this._pendingQueue = new PendingSendQueue(this);
            this._receivingQueue = new ReceivingQueue(this);

            this.SocketBufferSize = 8 * 1024;
            this.FreeBufferPoolSize = 10;
            this.FreeBufferPoolHold = FreeBufferPoolSize*3;
            this.KeepAliveTime = 0;

            this.OnConnect += OnConnectCallBack;
            this.OnSend += OnSendCallBack;
            this.OnReceive += OnReceiveCallBack;
            this.OnClose += OnCloseCallBack;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// 是否是主动断开连接
        /// </summary>
        public bool IsInitiative { get; set; }

        /// <summary>
        /// 是否在连接状态
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// 发送超时毫秒数
        /// </summary>
        public int MillisecondsSendTimeout
        {
            get { return this._millisecondsSendTimeout; }
        }

        /// <summary>
        /// 接收超时毫秒数
        /// </summary>
        public int MillisecondsReceiveTimeout
        {
            get { return this._millisecondsReceiveTimeout; }
        }

        /// <summary>
        /// 接收未知消息事件
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> OnReceivedUnKnowMsgEvent;

        /// <summary>
        /// socket关闭事件
        /// </summary>
        public event EventHandler<SocketCloseEventArgs> OnSocketCloseEvent; 
        #endregion

        #region Public Methods
        /// <summary>
        /// TCP连接对象
        /// </summary>
        public static SocketClient Tcp
        {
            get { return _defaultInstance ?? (_defaultInstance = new SocketClient(3000, 3000)); }
        }

        /// <summary>
        /// 产生不重复的seqID
        /// </summary>
        /// <returns></returns>
        public int NextRequestSeqId()
        {
            return Interlocked.Increment(ref this._seqId) & 0x7fffffff;
        }

        /// <summary>
        /// 直接发送数据
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public bool SendPacket(byte[] bytes)
        {
            if (!IsStarted)
            {
                LogHepler.Log.Info("Connection has been disconnected. Data cannot be sent.");
                return false;
            }

            try
            {
                return this.Send(bytes, bytes.Length);
            }
            catch (Exception ex)
            {
                LogHepler.Log.ErrorFormat("Send Packet Exception. {0}", ex.StackTrace);
            }

            return false;
        }

        /// <summary>
        /// 发送请求(有重发、超时、异常、回调控制)
        /// </summary>
        /// <param name="request"></param>
        public void SendRequest(Request request)
        {
            if (request == null) return;
            if (!IsStarted)
            {
                LogHepler.Log.Info("Connection has been disconnected. Request cannot be sent.");
                OnDisConnected(request);
                return;
            }

            if (!SendPacket(request.Content))
            {
                request.SentTime = DateEx.UtcNow;
                if (request.AllowRetry)
                {
                    _pendingQueue.Enqueue(request);
                }
                else
                {
                    OnSendFailed(request);
                }
            }

            _receivingQueue.TryAdd(request);

            LogHepler.Log.DebugFormat("Sent Request. Id:[{0}]  Name:[{1}] ", request.SeqId, request.Name);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// 发送下一个请求
        /// </summary>
        protected void TrySendNext()
        {
            Request request = null;
            if (this._pendingQueue.TryDequeue(out request)) this.SendRequest(request);
        }

        /// <summary>
        /// 发送消息成功后回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        protected HandleResult OnSendCallBack(TcpClient sender, byte[] bytes)
        {
            return HandleResult.Ok;
        }


        /// <summary> 
        /// 接收服务端的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private HandleResult OnReceiveCallBack(TcpClient sender, byte[] bytes)
        {
            if (bytes == null) return HandleResult.Error;

            var bufferList = new List<byte[]>();
            _parser.TryParsing(ref bytes, ref bufferList);
            //if (buffer == null) return HandleResult.Ok;

            foreach (var buffer in bufferList)
            {
                var packet = buffer;

                try
                {
                    var header = BytesReader.ReadBuffer(ref packet, 4, RespHeader.Length);
                    var respHeader = new RespHeader();
                    respHeader.Deserialize(ref header);
                    var reqId = respHeader.RequestId;

                    //发送的请求，返回的数据
                    Request request;
                    if (_receivingQueue.TryRemove(this.ConnectionId.ToInt64(), reqId, out request))
                    {
                        request.Content = packet;
                        OnReceivedMessage(request);
                    }
                    else
                    {
                        //未知数据
                        OnReceivedUnknowMessage(new MessageReceivedEventArgs(packet, packet.Length));
                    }
                }
                catch (Exception ex)
                {
                    //未知数据
                    OnReceivedUnknowMessage(new MessageReceivedEventArgs(packet, packet.Length));
                    LogHepler.Log.ErrorFormat("Receive Packet Exception. {0}", ex.StackTrace);
                }
            }

            return HandleResult.Ok;
        }

        /// <summary>
        /// 响应的消息
        /// </summary>
        /// <param name="request"></param>
        protected virtual void OnReceivedMessage(Request request)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    LogHepler.Log.DebugFormat("Received Request. Id:[{0}]  Name:[{1}] ", request.SeqId, request.Name);
                    request.SetResult(request.Content);
                }
                catch (Exception ex)
                {
                    LogHepler.Log.ErrorFormat("Received Request Exception. Id:[{0}]  Name:[{1}]  Exception:{2} ",
                        request.SeqId, request.Name, ex.StackTrace);
                }
            });
        }

        /// <summary>
        /// 接收未知消息(服务端推送的或者未知)
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnReceivedUnknowMessage(MessageReceivedEventArgs e)
        {
            var handler = OnReceivedUnKnowMsgEvent;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// 发送超时
        /// </summary>
        /// <param name="request"></param>
        protected virtual void OnPendingSendTimeout(Request request)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    LogHepler.Log.ErrorFormat("Id:[{0}]  Name:[{1}] Code:[{2}]", request.SeqId, request.Name, 
                        Convert.ToInt32(RequestException.EnumErrorCode.PendingSendTimeout));
                    request.SetException(new RequestException(request.CnName, RequestException.EnumErrorCode.PendingSendTimeout));
                }
                catch (Exception ex)
                {
                    LogHepler.Log.ErrorFormat("Send Packet TimeOut Exception. {0}", ex.StackTrace);
                }
            });
        }

        /// <summary>
        /// 发送失败
        /// </summary>
        /// <param name="request"></param>
        protected virtual void OnSendFailed(Request request)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    LogHepler.Log.ErrorFormat("Id:[{0}]  Name:[{1}] Code:[{2}]", request.SeqId, request.Name, 
                        Convert.ToInt32(RequestException.EnumErrorCode.SendFaild));
                    request.SetException(new RequestException(request.CnName, RequestException.EnumErrorCode.SendFaild));
                }
                catch (Exception ex)
                {
                    LogHepler.Log.ErrorFormat("Send Packet Exception. {0}", ex.StackTrace);
                }
            });
        }

        /// <summary>
        /// 接收消息超时
        /// </summary>
        /// <param name="request"></param>
        protected virtual void OnReceiveTimeout(Request request)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    LogHepler.Log.ErrorFormat("Id:[{0}]  Name:[{1}] Code:[{2}]", request.SeqId, request.Name, 
                        Convert.ToInt32(RequestException.EnumErrorCode.ReceiveTimeout));
                    request.SetException(new RequestException(request.CnName, RequestException.EnumErrorCode.ReceiveTimeout));
                }
                catch (Exception ex)
                {
                    LogHepler.Log.ErrorFormat("Receive Packet TimeOut Exception. {0}", ex.StackTrace);
                }
            });
        }

        /// <summary>
        /// 连接已断开
        /// </summary>
        /// <param name="request"></param>
        protected virtual void OnDisConnected(Request request)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    LogHepler.Log.ErrorFormat("Id:[{0}]  Name:[{1}] Code:[{2}]", request.SeqId, request.Name, 
                        Convert.ToInt32(RequestException.EnumErrorCode.Disconnected));
                    request.SetException(new RequestException(string.Empty, RequestException.EnumErrorCode.Disconnected));
                }
                catch (Exception ex)
                {
                    LogHepler.Log.ErrorFormat("Connection has been disconnected Exception. {0}", ex.StackTrace);
                }
            });
        }

        protected virtual void OnSocketClose(SocketCloseEventArgs e)
        {
            var handler = OnSocketCloseEvent;
            if (handler != null) handler(this, e);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// 连接成功
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private HandleResult OnConnectCallBack(TcpClient sender)
        {
            IsConnected = true;
            IsInitiative = false;
            _timer = new Timer(IsConnectedCallBack, null, 0, 3000);
            LogHepler.Log.InfoFormat("Connection [{0}] Start.", this.ConnectionId);
            return HandleResult.Ok;
        }

        /// <summary>
        /// 本地网络是否在连接状态
        /// </summary>
        /// <param name="obj"></param>
        private void IsConnectedCallBack(object obj)
        {
            int errorCode;
            InternetGetConnectedState(out errorCode, 0);

            if (!InternetGetConnectedState(out errorCode, 0))
            {
                if (_timer != null)
                {
                    _timer.Dispose();
                }

                if (IsConnected)
                {
                    IsConnected = false;
                    OnSocketClose(new SocketCloseEventArgs(errorCode, IsInitiative));
                }

                LogHepler.Log.InfoFormat("Connection [{0}] Stop. Code: {1} ", this.ConnectionId, errorCode);
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="enOperation"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        private HandleResult OnCloseCallBack(TcpClient sender, SocketOperation enOperation, int errorCode)
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }
            
            if (IsConnected)
            {
                IsConnected = false;
                OnSocketClose(new SocketCloseEventArgs(errorCode, IsInitiative));
            }

            LogHepler.Log.InfoFormat("Connection [{0}] Stop. Code: {1} ", this.ConnectionId, errorCode);
            
            return HandleResult.Ok;
        }
        #endregion

        /// <summary>
        /// 发送队列
        /// </summary>
        private class PendingSendQueue
        {
            #region Private Members
            private readonly SocketClient _client = null;
            private readonly ConcurrentQueue<Request> _queue =
                new ConcurrentQueue<Request>();
            private readonly Timer _timer = null;
            #endregion

            #region Constructors
            /// <summary>
            /// new
            /// </summary>
            /// <param name="client"></param>
            public PendingSendQueue(SocketClient client)
            {
                this._client = client;

                this._timer = new Timer(state =>
                {
                    var count = this._queue.Count;
                    if (count == 0) return;

                    this._timer.Change(Timeout.Infinite, Timeout.Infinite);

                    var dtNow = DateEx.UtcNow;
                    var timeOut = this._client.MillisecondsSendTimeout;
                    while (count-- > 0)
                    {
                        Request request;
                        if (!this._queue.TryDequeue(out request)) break;

                        if (dtNow.Subtract(request.CreatedTime).TotalMilliseconds < timeOut)
                        {
                            //try send...
                            this._client.SendRequest(request);
                            continue;
                        }

                        //fire send time out
                        this._client.OnPendingSendTimeout(request);
                    }

                    this._timer.Change(PeriodTime, PeriodTime);
                }, null, PeriodTime, PeriodTime);
            }
            #endregion

            #region Public Methods
            /// <summary>
            /// 入列
            /// </summary>
            /// <param name="request"></param>
            /// <exception cref="ArgumentNullException">request is null</exception>
            public void Enqueue(Request request)
            {
                if (request == null) LogHepler.Log.Error("Request is null.");
                this._queue.Enqueue(request);
            }
            /// <summary>
            /// TryDequeue
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            public bool TryDequeue(out Request request)
            {
                return this._queue.TryDequeue(out request);
            }
            #endregion
        }

        /// <summary>
        /// 接收队列
        /// </summary>
        private class ReceivingQueue
        {
            #region Private Members
            /// <summary>
            /// socket client
            /// </summary>
            private readonly SocketClient _client = null;
            /// <summary>
            /// key:connectionID:request.SeqID
            /// </summary>
            private readonly ConcurrentDictionary<string, Request> _dic =
                new ConcurrentDictionary<string, Request>();
            /// <summary>
            /// timer for check receive timeout
            /// </summary>
            private readonly Timer _timer = null;
            #endregion

            #region Constructors
            /// <summary>
            /// new
            /// </summary>
            /// <param name="client"></param>
            public ReceivingQueue(SocketClient client)
            {
                this._client = client;

                this._timer = new Timer(_ =>
                {
                    if (this._dic.Count == 0) return;
                    this._timer.Change(Timeout.Infinite, Timeout.Infinite);

                    var dtNow = DateEx.UtcNow;
                    var arr = this._dic.ToArray().Where(c =>
                        dtNow.Subtract(c.Value.SentTime).TotalMilliseconds > c.Value.MillisecondsReceiveTimeout).ToArray();

                    for (int i = 0, l = arr.Length; i < l; i++)
                    {
                        Request request;
                        if (this._dic.TryRemove(arr[i].Key, out request))
                            this._client.OnReceiveTimeout(request);
                    }

                    this._timer.Change(PeriodTime, PeriodTime);
                }, null, PeriodTime, PeriodTime);
            }
            #endregion

            #region Private Methods
            /// <summary>
            /// to key
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            private string ToKey(Request request)
            {
                if (request.ConnectionId == 0) LogHepler.Log.Error("Connection Excption");
                return this.ToKey(request.ConnectionId, request.SeqId);
            }

            /// <summary>
            /// to key
            /// </summary>
            /// <param name="connectionId"></param>
            /// <param name="seqId"></param>
            /// <returns></returns>
            private string ToKey(long connectionId, long seqId)
            {
                return string.Concat(connectionId.ToString(), "/", seqId.ToString());
            }
            #endregion

            #region Public Methods
            /// <summary>
            /// try add
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            public bool TryAdd(Request request)
            {
                return this._dic.TryAdd(this.ToKey(request), request);
            }

            /// <summary>
            /// try remove
            /// </summary>
            /// <param name="connectionId"></param>
            /// <param name="seqId"></param>
            /// <param name="request"></param>
            /// <returns></returns>
            public bool TryRemove(long connectionId, long seqId, out Request request)
            {
                return this._dic.TryRemove(this.ToKey(connectionId, seqId), out request);
            }
            #endregion
        }
    }
}
