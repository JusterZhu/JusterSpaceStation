using MyAlgorithm.Graph;
using MyAlgorithm.Recursion;
using MyAlgorithm.Search;
using MyAlgorithm.Sort;
using MyAlgorithm.Tree;
using System;
using System.Diagnostics;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] array = { 53, 3, 542, 748, 14, 214 };
            Random random = new Random();
            int[] array = new int[8000000];
            for (int i = 0; i < array.Length; i++) 
            { 
                array[i] = random.Next(0, array.Length);
            }
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Restart();
            RedixSort.Sort(array);
            stopwatch.Stop();
            Console.WriteLine("耗时" + stopwatch.ElapsedMilliseconds + "毫秒");
            Console.Read();
        }
    }
}
