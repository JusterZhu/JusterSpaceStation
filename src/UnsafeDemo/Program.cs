namespace UnsafeDemo
{
    using System;
    using System.Diagnostics;

    class Program
    {
        const int size = 1000000000;
        static void Main()
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; ++i)
                arr[i] = i;

            Stopwatch sw = new Stopwatch();

            // 不使用 unsafe 的版本
            sw.Start();
            for (int i = 0; i < size; ++i)
                ++arr[i];
            sw.Stop();
            Console.WriteLine("Without unsafe: {0}ms", sw.ElapsedMilliseconds);

            // 使用 unsafe 的版本
            sw.Reset();
            sw.Start();
            unsafe
            {
                fixed (int* pArr = arr)
                {
                    int* pEnd = pArr + size;
                    for (int* p = pArr; p < pEnd; ++p)
                        ++(*p);
                }
            }
            sw.Stop();
            Console.WriteLine("With unsafe: {0}ms", sw.ElapsedMilliseconds);
        }
    }

}
