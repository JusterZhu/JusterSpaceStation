using System;
using X.NetCore.Utils;

namespace X.NetCore
{
    public class Request
    {
         #region Members
        /// <summary>
        /// 是否重新发送
        /// </summary>
        public bool AllowRetry { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime = DateEx.UtcNow;

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SentTime { get; set; }

        /// <summary>
        /// Socket连接ID
        /// </summary>
        public long ConnectionId { get; set; }

        /// <summary>
        /// seqID
        /// </summary>
        public long SeqId { get; set; }

        /// <summary>
        /// 请求名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 请求中文名称
        /// </summary>
        public string CnName { get; set; }

        /// <summary>
        /// 请求内容
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public int MillisecondsReceiveTimeout { get; set; }

        /// <summary>
        /// 异常回调
        /// </summary>
        private readonly Action<Exception> _onException = null;

        /// <summary>
        /// 结果回调
        /// </summary>
        private readonly Action<byte[]> _onResult = null;
        #endregion

        #region Constructors

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="seqId">seqID</param>
        /// <param name="connectionId">连接Id</param>
        /// <param name="name">请求名称</param>
        /// <param name="cnName">中文名称</param>
        /// <param name="sentTime">发送时时间</param>
        /// <param name="isRetry">是否重发</param>
        /// <param name="millisecondsReceiveTimeout">超时时间</param>
        /// <param name="bytes">请求内容</param>
        /// <param name="onException">异常回调</param>
        /// <param name="onResult">结果回调</param>
        /// <exception cref="ArgumentNullException">onException is null</exception>
        /// <exception cref="ArgumentNullException">onResult is null</exception>
        public Request(long seqId,
            long connectionId,
            string name,
            string cnName,
            DateTime sentTime,
            bool isRetry,
            int millisecondsReceiveTimeout,
            byte[] bytes,
            Action<Exception> onException,
            Action<byte[]> onResult)
        {
            if (onException == null) throw new ArgumentNullException("onException");
            if (onResult == null) throw new ArgumentNullException("onResult");

            this.SeqId = seqId;
            this.ConnectionId = connectionId;
            this.Name = name;
            this.CnName = cnName;
            this.SentTime = sentTime;
            this.AllowRetry = isRetry;
            this.MillisecondsReceiveTimeout = millisecondsReceiveTimeout;
            this.Content = bytes;
            this._onException = onException;
            this._onResult = onResult;
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="seqId">seqID</param>
        /// <param name="connectionId">连接Id</param>
        /// <param name="name">请求名称</param>
        /// <param name="cnName">中文名称</param>
        /// <param name="bytes">请求内容</param>
        /// <param name="onException">异常回调</param>
        /// <param name="onResult">结果回调</param>
        /// <exception cref="ArgumentNullException">onException is null</exception>
        /// <exception cref="ArgumentNullException">onResult is null</exception>
        public Request(long seqId,
           long connectionId,
           string name,
           string cnName,
           byte[] bytes,
           Action<Exception> onException,
           Action<byte[]> onResult) 
            : this(seqId, connectionId, name, cnName, DateEx.UtcNow, false, 30000, bytes, onException, onResult)
        {
         
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// 异常回调
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public bool SetException(Exception ex)
        {
            this._onException(ex);
            return true;
        }

        /// <summary>
        /// 结果回调
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public bool SetResult(byte[] bytes)
        {
            this._onResult(bytes);
            return true;
        }
        #endregion
    }
}
