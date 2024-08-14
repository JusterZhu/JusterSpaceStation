using System;

namespace X.NetCore.Events
{
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        public byte[] Bytes { get; set; }

        /// <summary>
        /// 消息内容长度
        /// </summary>
        public int Length { get; set; }

        public MessageReceivedEventArgs(byte[] bytes, int len)
        {
            Bytes = bytes;
            Length = len;
        }
    }
}
