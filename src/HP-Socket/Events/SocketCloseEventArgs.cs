using System;

namespace X.NetCore.Events
{
    public class SocketCloseEventArgs : EventArgs
    {
        public int ErrorCode { get; set; }

        public bool IsInitiative { get; set; }

        public SocketCloseEventArgs(int errorCode, bool isInitiative)
        {
            ErrorCode = errorCode;
            IsInitiative = isInitiative;
        }
    }
}
