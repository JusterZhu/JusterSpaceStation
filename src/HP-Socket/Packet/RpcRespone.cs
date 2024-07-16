using System;
using System.Text;
using Newtonsoft.Json;
using X.NetCore.Utils;

namespace X.NetCore.Packet
{
    public class RpcRespone<TMessage> : IPacket
        where TMessage : IMessage
    {
        /// <summary>
        /// 4个byte表示package长度
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// package头18个字节
        /// </summary>
        public RespHeader Header { get; set; }

        /// <summary>
        /// package内容
        /// </summary>
        public TMessage Body { get; set; }

        public byte[] Serialize()
        {
            var header = Header.Serialize();
            Length += header.Length;

            byte[] body = null;
            var json = JsonConvert.SerializeObject(Body);
            if (json != null)
            {
                body = Encoding.UTF8.GetBytes(json);
                Length += body.Length;
            }

            var package = new byte[4+Length];
            BytesWriter.Write(Length, ref package, 0);  //length
            BytesWriter.Write(header, ref package, 4);  //header
            if (body != null)
            {
                BytesWriter.Write(body, ref package, 4 + RespHeader.Length);   //body
            }
            
            return package;
        }

        public void Deserialize(ref byte[] data)
        {
            try
            {
                Length = BytesReader.ReadInt32(ref data, 0);

                var header = BytesReader.ReadBuffer(ref data, 4, RespHeader.Length);
                Header = new RespHeader();
                Header.Deserialize(ref header);
                var body = BytesReader.ReadBuffer(ref data, 4 + RespHeader.Length, Length - RespHeader.Length);
                var json = Encoding.UTF8.GetString(body);
                //LogHepler.Log.DebugFormat("JsonConvert Deserialize. Id:[{0}] body:[{1}]", Header.RequestId, json);
                Body = JsonConvert.DeserializeObject<TMessage>(json);
            }
            catch (Exception ex)
            {
                LogHepler.Log.ErrorFormat("JsonConvert Deserialize. {0}", ex.Message);
            }
        }
    }
}
