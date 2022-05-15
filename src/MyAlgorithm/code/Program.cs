using MyAlgorithm.Graph;
using MyAlgorithm.Search;
using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //初始化一个有序的100长度的数组
            int[] arr = { 1,8,10,89,1000,1234 };
            Console.WriteLine(FibonacciSearch.Search(arr,89));
            Console.Read();
        }
    }
}
