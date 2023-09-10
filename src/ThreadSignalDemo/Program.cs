namespace ThreadSignalDemo
{
    using System;
    using System.Threading;

    class Program
    {
        static AutoResetEvent autoEvent1 = new AutoResetEvent(true);
        static AutoResetEvent autoEvent2 = new AutoResetEvent(false);

        static void Main()
        {
            new Thread(PrintNumbers).Start();
            new Thread(PrintLetters).Start();

            Console.ReadLine();
        }

        static void PrintNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                autoEvent1.WaitOne(); // 等待信号
                Console.WriteLine(i);
                autoEvent2.Set();     // 发出信号
            }
        }

        static void PrintLetters()
        {
            for (char letter = 'A'; letter < 'K'; letter++)
            {
                autoEvent2.WaitOne(); // 等待信号
                Console.WriteLine(letter);
                autoEvent1.Set();     // 发出信号
            }
        }
    }

}
