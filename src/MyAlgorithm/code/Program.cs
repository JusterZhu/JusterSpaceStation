using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BTree tree = new BTree();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                tree.Insert(random.Next(100));
            }
            tree.PrintByIndex();
            Console.Read();
        }
    }
}
