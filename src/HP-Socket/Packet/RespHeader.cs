using System;
using X.NetCore.Utils;

namespace X.NetCore.Packet
{
    /*18个字节长度*/
    public class RespHeader : IPacket
    {
        public const int Length = 18;

        /// <summary>
        /// 包头标志，用于校验
        /// </summary>
        public byte Checkbit { get; set; }

        /// <summary>
        /// 8个字节，请求ID
        /// </summary>
        public long RequestId { get; set; }

        /// <summary>
        /// 4个字节，返回结果状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 1个字节，是否加密
        /// </summary>
        public bool IsEncrypt { get; set; }

        /// <summary>
        /// 4个字节，命令ID
        /// </summary>
        public short CommandId { get;set; }

        /// <summary>
        /// 2个字节，扩展参数
        /// </summary>
        public short Ext1{get; set; }


        public byte[] Serialize()
        {
            Checkbit = Header.Checkbit;
            var header = new byte[18];
            try
            {
                BytesWriter.Write(Checkbit, ref header, 0);
                BytesWriter.Write(RequestId, ref header, 1);
                BytesWriter.Write(Code, ref header, 9);
                BytesWriter.Write(IsEncrypt, ref header, 13);
                BytesWriter.Write(CommandId, ref header, 14);
                BytesWriter.Write(Ext1, ref header, 16);
            }
            catch (Exception ex)
            {
                LogHepler.Log.ErrorFormat("Serialize Respone Header Exception. {0}", ex.Message);
            }
       
            return header;
        }

        public void Deserialize(ref byte[] data)
        {
            try
            {
                Checkbit = BytesReader.ReadByte(ref data, 0);
                RequestId = BytesReader.ReadInt64(ref data, 1);
                Code = BytesReader.ReadInt32(ref data, 9);
                IsEncrypt = BytesReader.ReadBool(ref data, 13);
                CommandId = BytesReader.ReadInt16(ref data, 14);
                Ext1 = BytesReader.ReadInt16(ref data, 16);
            }
            catch (Exception ex)
            {
                LogHepler.Log.ErrorFormat("Deserialize Respone Header Exception. {0}", ex.Message);
            }
        }
    }
}
