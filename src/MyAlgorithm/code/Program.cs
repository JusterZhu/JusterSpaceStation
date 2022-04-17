using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////创建树
            //var tree = new BinaryTree();

            ////创建需要的节点
            //TreeNode root = new TreeNode(1,"名册");
            //TreeNode node2 = new TreeNode(2, "张三");
            //TreeNode node3 = new TreeNode(3,"李四");
            //TreeNode node4 = new TreeNode(4,"王五");
            //TreeNode node5 = new TreeNode(5, "赵六");


            ////手动创建二叉树
            //root.Left = node2;
            //root.Right = node3;
            //node3.Left = node5;
            //node3.Right = node4;
            //tree.SetRoot(root);

            //Console.WriteLine("删除前，前序遍历");
            //tree.PreOrder();
            //tree.DeleteNode(5);
            //Console.WriteLine("删除后，前序遍历");
            //tree.PreOrder();
            //tree.DeleteNode(3);
            //Console.WriteLine("删除后，前序遍历");
            //tree.PreOrder();
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            ArrayBinaryTree arrayBinaryTree = new ArrayBinaryTree(array);
            arrayBinaryTree.PreOrder();
            Console.Read();
        }
    }
}
