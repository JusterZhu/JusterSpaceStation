using System.Diagnostics;

namespace TraceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            Trace.AutoFlush = true;
            
            while (true)
            {
                Thread.Sleep(1000);
                Trace.Write("Trace message.");
            }
        }
    }
}
