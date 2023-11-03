using System;
using System.Runtime.InteropServices;

public class FileSystemTransaction : IDisposable
{
    private IntPtr _transaction;

    [DllImport("ktmw32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern IntPtr CreateTransaction(IntPtr lpTransactionAttributes, IntPtr UOW, int CreateOptions,
        int IsolationLevel, int IsolationFlags, int Timeout, string Description);

    [DllImport("ktmw32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern bool CommitTransaction(IntPtr TransactionHandle);

    [DllImport("ktmw32.dll", SetLastError = true)]
    static extern bool RollbackTransaction(IntPtr TransactionHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool CloseHandle(IntPtr hObject);

    public FileSystemTransaction(string description)
    {
        _transaction = CreateTransaction(IntPtr.Zero, IntPtr.Zero, 0, 0, 0, 0, description);

        if (_transaction == IntPtr.Zero)
            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
    }

    public void Commit()
    {
        if (!CommitTransaction(_transaction))
            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
    }

    public void Rollback()
    {
        if (!RollbackTransaction(_transaction))
            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
    }

    public void Dispose()
    {
        CloseHandle(_transaction);
    }
}
