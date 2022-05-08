using MyAlgorithm.Graph;
using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //数组进行升序排序
            int[] arr = { 4, 6, 8, 5, 9,-1,90,89,56,-999 };
            HeapSort.HeapSort0(arr);
            Console.Read();
        }
    }
}
