using System;
using X.NetCore.Utils;

namespace X.NetCore.Packet
{
    /*
     * 总共24个字节
     * 1个固定的byte 值为0x1F, 包头标志，用于区分是否是我们发送的package
     * 8个byte表示uid
     * 8个byte表示是requestId
     * 1个bit表示是否加密
     * 2个byte表示commandId
     * 2个byte表示扩展位1的长度
     * 2个byte表示扩展位2的长度
     */
    public class ReqHeader : IPacket
    {
        public const int Length = 24;

        /// <summary>
        /// 包头标志，用于校验
        /// </summary>
        public byte Checkbit { get; set; }

        /// <summary>
        /// 8个byte表示uid
        /// </summary>
        public long Uid { get; set; }

        /// <summary>
        /// 8个byte表示是requestId
        /// </summary>
        public long RequestId { get; set; }

        /// <summary>
        /// 1个bit表示是否加密
        /// </summary>
        public bool IsEncrypt { get; set; }

        /// <summary>
        /// 2个byte表示commandId
        /// </summary>
        public short CommandId { get; set; }

        /// <summary>
        /// 2个byte表示扩展位1的长度
        /// </summary>
        public short Ext1 { get; set; }

        /// <summary>
        /// 2个byte表示扩展位2的长度
        /// </summary>
        public short Ext2 { get; set; }

        public byte[] Serialize()
        {
            Checkbit = Header.Checkbit;
            var header = new byte[24];

            try
            {
                BytesWriter.Write(Checkbit, ref header, 0);
                BytesWriter.Write(Uid, ref header, 1);
                BytesWriter.Write(RequestId, ref header, 9);
                BytesWriter.Write(IsEncrypt, ref header, 17);
                BytesWriter.Write(CommandId, ref header, 18);
                BytesWriter.Write(Ext1, ref header, 20);
                BytesWriter.Write(Ext2, ref header, 22);
            }
            catch (Exception ex)
            {
                LogHepler.Log.ErrorFormat("Serialize Request Header Exception. {0}", ex.Message);
            }
          
            return header;
        }

        public void Deserialize(ref byte[] data)
        {
            try
            {
                Checkbit = BytesReader.ReadByte(ref data, 0);
                Uid = BytesReader.ReadInt64(ref data, 1);
                RequestId = BytesReader.ReadInt64(ref data, 9);
                IsEncrypt = BytesReader.ReadBool(ref data, 17);
                CommandId = BytesReader.ReadInt16(ref data, 18);
                Ext1 = BytesReader.ReadInt16(ref data, 20);
                Ext2 = BytesReader.ReadInt16(ref data, 22);
            }
            catch (Exception ex)
            {
                LogHepler.Log.ErrorFormat("Serialize Request Header Exception. {0}", ex.Message);
            }
        }
     } 
}
