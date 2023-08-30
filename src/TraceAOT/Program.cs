using System.Diagnostics;

namespace TraceAOT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("MyTraceListeners"));
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Trace.WriteLineIf(i==5, "Trace message.");
            }
            Trace.Flush();
            Console.WriteLine("OK");
            Console.Read();
        }
    }
}
