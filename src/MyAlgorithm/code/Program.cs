using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadedBinaryNode root = new ThreadedBinaryNode(1,"tom");
            ThreadedBinaryNode node2 = new ThreadedBinaryNode(3,"jack");
            ThreadedBinaryNode node3 = new ThreadedBinaryNode(6,"simth");
            ThreadedBinaryNode node4 = new ThreadedBinaryNode(8,"mary");
            ThreadedBinaryNode node5 = new ThreadedBinaryNode(10,"king");
            ThreadedBinaryNode node6 = new ThreadedBinaryNode(14,"dim");
            root.Left = node2;
            root.Right = node3;
            node2.Left = node4; 
            node2.Right = node5;
            node3.Left = node6;
            ThreadedBinaryTree threadedBinaryTree = new ThreadedBinaryTree();
            threadedBinaryTree.SetRoot(root);
            threadedBinaryTree.SetThreadedBinaryNode();
            ThreadedBinaryNode leftNode = node5.Left;
            Console.WriteLine("10号节点的前驱节点是：" + leftNode);

            ThreadedBinaryNode rightNode = node5.Right;
            Console.WriteLine("10号节点的后继节点是：" + rightNode);

            Console.WriteLine("线索化的方式遍历线索化二叉树");
            threadedBinaryTree.ThreadedList();// 8,3,10,1,14,6
            //当线索化二叉树后，能在
            Console.Read();
        }
    }
}
