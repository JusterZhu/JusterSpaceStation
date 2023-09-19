namespace ManualResetEventDemo
{
    using System;
    using System.Threading;

    class Program
    {
        private static ManualResetEvent manualEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(ThreadProc);
            thread1.Name = "Thread1";
            thread1.Start();

            Thread thread2 = new Thread(ThreadProc);
            thread2.Name = "Thread2";
            thread2.Start();

            Console.WriteLine("Waiting for threads to complete.");
            manualEvent.Set();  // Signal that work can be done.
            thread1.Join();
            thread2.Join();

            Console.WriteLine("All threads have completed.");
        }

        static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine($"{name} waits on ManualResetEvent.");
            manualEvent.WaitOne();  // Wait for the signal.
            Console.WriteLine($"{name} receives a signal to proceed.");
            // Do some work...
        }
    }

}
