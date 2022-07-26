using MyAlgorithm.Graph;
using MyAlgorithm.Recursion;
using MyAlgorithm.Search;
using MyAlgorithm.Sort;
using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { -9,78,0,23,-567,70,-1,900,4561 };
            QuickSort.Sort(array,0,array.Length - 1);
            Console.Read();
        }
    }
}
