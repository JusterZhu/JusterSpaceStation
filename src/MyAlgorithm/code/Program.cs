using MyAlgorithm.Graph;
using MyAlgorithm.Recursion;
using MyAlgorithm.Search;
using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queen8 queen8 = new Queen8();
            queen8.Check(0);
            Console.WriteLine("一共有" + Queen8.count + "解法！！");
            Console.Read();
        }
    }
}
