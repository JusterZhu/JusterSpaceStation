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
            int[] array = { 8,9,1,7,2,3,5,4,6,0};
            ShellSort.Sort(array);
            Console.Read();
        }
    }
}
