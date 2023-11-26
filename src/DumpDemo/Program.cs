using Microsoft.Diagnostics.NETCore.Client;

namespace DumpDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int processId = int.Parse(args[0]); // The process ID to collect the dump from
            string dumpFilePath = args[1]; // The path where the dump file should be written

            CreateDump(processId, dumpFilePath);
        }

        public static void CreateDump(int processId, string dumpFilePath)
        {
            var client = new DiagnosticsClient(processId);

            // Dumper.CollectDump(Process process, string dumpFileName, DumpTypeOption type)
            client.WriteDump(DumpType.Normal, dumpFilePath);
        }
    }
}
