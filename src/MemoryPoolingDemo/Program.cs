namespace MemoryPoolingDemo
{
    using System;

    class Program
    {
        static void Main()
        {
            // 不使用MemoryPool的情况
            Console.WriteLine("不使用MemoryPool：");
            for (int i = 0; i < 5000; i++)
            {
                byte[] byteArray = new byte[1024 * 1024]; // 分配1MB的内存
                Console.WriteLine($"分配了 {byteArray.Length / 1024} KB 内存");
                // 在这里模拟对内存的操作
                // ...
            }
            Console.Read();
        }
    }
}
