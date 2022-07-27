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
            int[] array = { 8,4,5,7,1,3,6,2 };
            //归并排序需要一个额外的空间
            int[] temp =new int[array.Length];
            MergeSort.Sort(array,0,array.Length - 1, temp);
            Console.WriteLine(string.Join(' ', array));
            Console.Read();
        }
    }
}
