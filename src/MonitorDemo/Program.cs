namespace MonitorDemo
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    class Program
    {
        private static int counter = 0;
        private static object lockObject = new object();
        private static object monitorObject = new object();

        static void Main()
        {
            // 使用Monitor进行性能测试
            Stopwatch monitorStopwatch = new Stopwatch();
            monitorStopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                lock (monitorObject)
                {
                    counter++;
                }
            }

            monitorStopwatch.Stop();
            Console.WriteLine($"Using Monitor: {monitorStopwatch.ElapsedMilliseconds} ms");

            // 使用lock进行性能测试
            Stopwatch lockStopwatch = new Stopwatch();
            lockStopwatch.Start();

            for (int i = 0; i < 1000000; i++)
            {
                Monitor.Enter(lockObject);
                try
                {
                    counter++;
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }

            lockStopwatch.Stop();
            Console.WriteLine($"Using lock: {lockStopwatch.ElapsedMilliseconds} ms");
        }
    }

}
