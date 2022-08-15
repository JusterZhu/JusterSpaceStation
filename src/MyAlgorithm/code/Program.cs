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
            HashTable hashTable = new HashTable(7);
            hashTable.Add(new Emp(2345, "emp" + 678, 15));
            hashTable.Add(new Emp(1, "emp" + 678, 15));
            hashTable.Add(new Emp(2, "emp" + 678, 15));
            hashTable.Add(new Emp(123, "emp" + 678, 15));
            hashTable.Print();
            hashTable.FindEmpById(8);
            Console.Read();
        }
    }
}
