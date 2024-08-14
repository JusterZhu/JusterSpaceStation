using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpDemoFramework
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Diagnostics;

    public class Program
    {
        [Flags]
        public enum Option : uint
        {
            // These options are omitted for brevity, see MSDN for more details.
            MiniDumpWithFullMemory = 0x00000002,
            MiniDumpWithHandleData = 0x00000004
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct MiniDumpExceptionInformation
        {
            public uint ThreadId;
            public IntPtr ExceptionPointers;
            [MarshalAs(UnmanagedType.Bool)]
            public bool ClientPointers;
        }

        [DllImport("dbghelp.dll", SetLastError = true)]
        public static extern bool MiniDumpWriteDump(IntPtr hProcess,
            uint processId,
            SafeHandle hFile,
            uint dumpType,
            ref MiniDumpExceptionInformation expParam,
            IntPtr userStreamParam,
            IntPtr callbackParam);

        public static void Main()
        {
            CreateDump();
        }

        public static void CreateDump()
        {
            // Get the current running process.
            Process currentProcess = Process.GetCurrentProcess();

            // Create an ExceptionInformation object
            MiniDumpExceptionInformation eInfo = new MiniDumpExceptionInformation();
            eInfo.ThreadId = (uint)currentProcess.Threads[0].Id;
            eInfo.ExceptionPointers = Marshal.GetExceptionPointers();
            eInfo.ClientPointers = false;

            string filePath = @"d:\temp\dumpfile.dmp";
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                bool success = MiniDumpWriteDump(currentProcess.Handle, (uint)currentProcess.Id, stream.SafeFileHandle, (uint)Option.MiniDumpWithFullMemory, ref eInfo, IntPtr.Zero, IntPtr.Zero);
                if (!success)
                {
                    throw new Exception("MiniDumpWriteDump failed");
                }
            }
        }
    }
}
