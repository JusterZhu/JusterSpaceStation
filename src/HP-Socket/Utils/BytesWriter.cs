using System;
using System.IO;

namespace X.NetCore.Utils
{
    /// <summary>
    /// binary writer
    /// </summary>
    public static class BytesWriter
    {
        /// <summary>
        /// write byte
        /// </summary>
        /// <param name="value">写入的数据</param>
        /// <param name="buffer">目标数组</param>
        /// <param name="offset">偏移量</param>
        public static void Write(byte value, ref byte[] buffer, int offset)
        {
            if (buffer.Length < offset + 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            using (var ms = new MemoryStream())
            {
                ms.WriteByte(value);
                ms.ToArray().CopyTo(buffer, offset);
            }
        }

        /// <summary>
        /// write byte array
        /// </summary>
        /// <param name="value">写入的数据</param>
        /// <param name="buffer">目标数组</param>
        /// <param name="offset">偏移量</param>
        public static void Write(byte[] value, ref byte[] buffer, int offset)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (buffer.Length < offset + value.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            using (var ms = new MemoryStream())
            {
                ms.Write(value, 0, value.Length);
                ms.ToArray().CopyTo(buffer, offset);
            }
        }

        /// <summary>
        /// write bool
        /// </summary>
        /// <param name="value">写入的数据</param>
        /// <param name="buffer">目标数组</param>
        /// <param name="offset">偏移量</param>
        public static void Write(bool value, ref byte[] buffer, int offset)
        {
            if (buffer.Length < offset + 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            using (var ms = new MemoryStream())
            {
                ms.WriteByte(value ? (byte)1 : (byte)0);
                ms.ToArray().CopyTo(buffer, offset);
            }
        }

        /// <summary>
        /// write short
        /// </summary>
        /// <param name="value">写入的数据</param>
        /// <param name="buffer">目标数组</param>
        /// <param name="offset">偏移量</param>
        public static void Write(short value, ref byte[] buffer, int offset)
        {
            if (buffer.Length < offset + 2)
            {
                throw new ArgumentOutOfRangeException();
            }

            using (var ms = new MemoryStream())
            {
                var tempBuffer = new byte[2];
                tempBuffer[0] = (byte)(0xff & (value >> 8));
                tempBuffer[1] = (byte)(0xff & value);
                ms.Write(tempBuffer, 0, 2);
                ms.ToArray().CopyTo(buffer, offset);
            }
        }

        /// <summary>
        /// write int
        /// </summary>
        /// <param name="value">写入的数据</param>
        /// <param name="buffer">目标数组</param>
        /// <param name="offset">偏移量</param>
        public static void Write(int value, ref byte[] buffer, int offset)
        {
            if (buffer.Length < offset + 4)
            {
                throw new ArgumentOutOfRangeException();
            }

            using (var ms = new MemoryStream())
            {
                var tempBuffer = new byte[4];
                tempBuffer[0] = (byte)(0xff & (value >> 24));
                tempBuffer[1] = (byte)(0xff & (value >> 16));
                tempBuffer[2] = (byte)(0xff & (value >> 8));
                tempBuffer[3] = (byte)(0xff & value);
                ms.Write(tempBuffer, 0, 4);
                ms.ToArray().CopyTo(buffer, offset);
            }
        }

        /// <summary>
        /// write long
        /// </summary>
        /// <param name="value">写入的数据</param>
        /// <param name="buffer">目标数组</param>
        /// <param name="offset">偏移量</param>
        public static void Write(long value, ref byte[] buffer, int offset)
        {
            if (buffer.Length < offset + 8)
            {
                throw new ArgumentOutOfRangeException();
            }

            using (var ms = new MemoryStream())
            {
                var tempBuffer = new byte[8];
                tempBuffer[0] = (byte)(0xff & (value >> 56));
                tempBuffer[1] = (byte)(0xff & (value >> 48));
                tempBuffer[2] = (byte)(0xff & (value >> 40));
                tempBuffer[3] = (byte)(0xff & (value >> 32));
                tempBuffer[4] = (byte)(0xff & (value >> 24));
                tempBuffer[5] = (byte)(0xff & (value >> 16));
                tempBuffer[6] = (byte)(0xff & (value >> 8));
                tempBuffer[7] = (byte)(0xff & value);
                ms.Write(tempBuffer, 0, 8);
                ms.ToArray().CopyTo(buffer, offset);
            }
        }
    }
}