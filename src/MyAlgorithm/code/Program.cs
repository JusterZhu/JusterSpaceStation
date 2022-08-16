using MyAlgorithm.Graph;
using MyAlgorithm.LinkList;
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
            int[] array = new int[] { 13,7,8,3,29,6,1 };
            HuffmanNode root =   HuffmanTree.Create(array);
            HuffmanTree.PreOrder(root);
            Console.Read();
        }
    }
}
