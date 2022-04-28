using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 7,3,10,12,5,1,9 ,2 };
            BinarySortTree root = new BinarySortTree();
            foreach (var item in array)
            {
                root.Add(new BinarySortNode(item));
            }
            Console.WriteLine("中序遍历二叉排序树！");
            root.InfixOrder();

            Console.WriteLine("中序遍历二叉排序树！");
            //root.DelNode(7);
            //root.DelNode(3);
            root.DelNode(10);

            root.InfixOrder();
            Console.Read();
        }
    }
}
