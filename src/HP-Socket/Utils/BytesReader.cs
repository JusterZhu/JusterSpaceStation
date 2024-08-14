using System;

namespace X.NetCore.Utils
{
    /// <summary>
    /// binary reader
    /// </summary>
    public static class BytesReader
    {
        /// <summary>
        /// read byte
        /// </summary>
        /// <param name="buffer">源数组</param>
        /// <param name="offset">源偏移量</param> 
        /// <returns></returns>
        public static byte ReadByte(ref byte[] buffer, int offset)
        {
            if (buffer.Length < offset + 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return buffer[offset];
        }

        /// <summary>
        /// read buffer
        /// </summary>
        /// <param name="buffer">源数组</param>
        /// <param name="offset">源偏移量</param>
        /// <param name="count">长度</param>
        /// <returns></returns>
        public static byte[] ReadBuffer(ref byte[] buffer, int offset, int count)
        {
            if (buffer.Length < offset + count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var tempBuffer = new byte[count];
            Array.Copy(buffer, offset, tempBuffer, 0, tempBuffer.Length);
            return tempBuffer;
        }

        /// <summary>
        /// read bool
        /// </summary>
        /// <param name="buffer">源数组</param>
        /// <param name="offset">源偏移量</param>
        /// <returns></returns>
        public static bool ReadBool(ref byte[] buffer, int offset)
        {
            if (buffer.Length < offset + 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return buffer[offset] == 1;
        }

        /// <summary>
        /// read int16
        /// </summary>
        /// <param name="buffer">源数组</param>
        /// <param name="offset">源偏移量</param>
        /// <returns></returns>
        public static short ReadInt16(ref byte[] buffer, int offset)
        {
            if (buffer.Length < offset+2)
            {
                throw new ArgumentOutOfRangeException();
            }

            var tempBuffer = new byte[2];
            Array.Copy(buffer, offset, tempBuffer, 0, tempBuffer.Length);
            return (short)(((tempBuffer[0] & 0xff) << 8) | ((tempBuffer[1] & 0xff)));
        }

        /// <summary>
        /// read int32
        /// </summary>
        /// <param name="buffer">源数组</param>
        /// <param name="offset">源偏移量</param>
        /// <returns></returns>
        public static int ReadInt32(ref byte[] buffer, int offset)
        {
            if (buffer.Length < offset+4)
            {
                throw new ArgumentOutOfRangeException();
            }

            var tempBuffer = new byte[4];
            Array.Copy(buffer, offset, tempBuffer, 0, tempBuffer.Length);
            return (int)(((tempBuffer[0] & 0xff) << 24) | ((tempBuffer[1] & 0xff) << 16) | ((tempBuffer[2] & 0xff) << 8) | ((tempBuffer[3] & 0xff)));
        }

        /// <summary>
        /// read int64
        /// </summary>
        /// <param name="buffer">源数组</param>
        /// <param name="offset">源偏移量</param>
        /// <returns></returns>
        public static long ReadInt64(ref byte[] buffer, int offset)
        {
            if (buffer.Length < offset + 8)
            {
                throw new ArgumentOutOfRangeException();
            }

            var tempBuffer = new byte[8];
            Array.Copy(buffer, offset, tempBuffer, 0, tempBuffer.Length);
            return (long)(((long)(tempBuffer[0] & 0xff) << 56) |
                ((long)(tempBuffer[1] & 0xff) << 48) |
                ((long)(tempBuffer[2] & 0xff) << 40) |
                ((long)(tempBuffer[3] & 0xff) << 32) |
                ((long)(tempBuffer[4] & 0xff) << 24) |
                ((long)(tempBuffer[5] & 0xff) << 16) |
                ((long)(tempBuffer[6] & 0xff) << 8) |
                ((long)(tempBuffer[7] & 0xff)));
        }
    }
}