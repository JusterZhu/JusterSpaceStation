using System.Diagnostics;

namespace TraceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(1000);
                Trace.Write("Trace message.");
            }
        }
    }
}
