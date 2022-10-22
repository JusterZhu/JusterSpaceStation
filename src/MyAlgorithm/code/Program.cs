using MyAlgorithm.DAC;
using MyAlgorithm.Graph;
using MyAlgorithm.KMP;
using MyAlgorithm.LinkList;
using MyAlgorithm.Recursion;
using MyAlgorithm.Search;
using MyAlgorithm.Sort;
using MyAlgorithm.Tree;
using System;
using System.Diagnostics;
using System.Linq;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "BBD ABCDAB ABCDABCDABDE";
            string str2 = "ABCDABD";
            int[] nextArray = KMPAlgorithm.KMPNext(str2);
            Console.WriteLine("NEXT=" + string.Join(' ',nextArray));
            Console.Read();
        }
    }
}
