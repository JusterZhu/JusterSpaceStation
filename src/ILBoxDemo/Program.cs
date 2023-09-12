namespace ILBoxDemo
{
    using System;
    using System.Diagnostics;

    public class Program
    {
        public static void Main()
        {
            const int numberOfOperations = 10000000; // 执行操作的次数
            int i = 1234;

            // 计时器开始
            Stopwatch stopwatch = new Stopwatch();

            // 测试装箱操作
            stopwatch.Start();
            for (int index = 0; index < numberOfOperations; index++)
            {
                object o = i; // 装箱操作
            }
            stopwatch.Stop();
            Console.WriteLine($"Boxing: {stopwatch.ElapsedMilliseconds} ms");

            // 测试拆箱操作
            object obj = i; // 先进行一次装箱
            stopwatch.Reset();
            stopwatch.Start();
            for (int index = 0; index < numberOfOperations; index++)
            {
                int value = (int)obj; // 拆箱操作
            }
            stopwatch.Stop();
            Console.WriteLine($"Unboxing: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

}
