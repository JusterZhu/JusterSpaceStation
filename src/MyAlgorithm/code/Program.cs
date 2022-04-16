using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //创建树
            var tree = new BinaryTree();

            //创建需要的节点
            TreeNode root = new TreeNode(1,"名册");
            TreeNode node2 = new TreeNode(2, "张三");
            TreeNode node3 = new TreeNode(3,"李四");
            TreeNode node4 = new TreeNode(4,"王五");


            //手动创建二叉树
            root.Left = node2;
            root.Right = node3;
            node3.Right = node4;
            tree.SetRoot(root);

            //测试
            Console.WriteLine("前序");
            tree.PreOrder();

            Console.WriteLine("中序");
            tree.InfixOrder();

            Console.WriteLine("后序");
            tree.PostOrder();

            Console.Read();
        }
    }
}
