using System;
using System.ComponentModel;
using System.Reflection;

namespace X.NetCore
{
    /// <summary>
    /// socket request exception
    /// </summary>
    public sealed class RequestException : ApplicationException
    {
        /// <summary>
        /// error
        /// </summary>
        public readonly EnumErrorCode ErrorCode;

        /// <summary>
        /// request name
        /// </summary>
        public readonly string RequestName;

        /// <summary>
        /// new
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        public RequestException(string name, EnumErrorCode code)
            : base(CombineMessage(name, code))
        {
            this.ErrorCode = code;
            this.RequestName = name;
        }

        /// <summary>
        /// error type enum
        /// </summary>
        public enum EnumErrorCode
        {
            [Description("未知错误！")]
            Unknow = 0,

            //等待发送超时
            [Description("超时！")]
            PendingSendTimeout = 1,

            //接收超时
            [Description("超时！")]
            ReceiveTimeout = 2,

            //发送失败
            [Description("失败！")]
            SendFaild = 3,

            [Description("哎呀(＞﹏＜)，已与服务器断开连接！")]
            Disconnected = 4,
        }

        private static string CombineMessage(string name, EnumErrorCode code)
        {
            var fieldInfo = code.GetType().GetField(code.ToString());
            if (fieldInfo == null) return null;
            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return string.IsNullOrEmpty(name) ? attribute.Description : string.Format("{0}{1}", name, attribute.Description);
        }
    }
}