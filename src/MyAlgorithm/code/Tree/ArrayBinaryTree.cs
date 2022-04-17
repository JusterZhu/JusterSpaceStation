using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Tree
{

    internal class ArrayBinaryTree
    {
        private int[] array;

        public ArrayBinaryTree(int[] array)
        {
           this.array = array;
        }

        public void PreOrder()
        {
            //如果数组为空，或者array.length = 0
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("数组为空，不能按照二叉树的前序遍历");
            }
            //输出当前这个元素
            Console.WriteLine(array[0]);
            //向左递归遍历
            if (2 * 0 + 1 < array.Length)
            {
                PreOrder(2 * 0 + 1);
            }
            //向右递归遍历
            if (2 * 0 + 2 < array.Length)
            {
                PreOrder(2 * 0 + 2);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">数组下标</param>
        public void PreOrder(int index)
        {
            //如果数组为空，或者array.length = 0
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("数组为空，不能按照二叉树的前序遍历");
            }
            //输出当前这个元素
            Console.WriteLine(array[index]);
            //向左递归遍历
            if (2 * index + 1 < array.Length)
            {
                PreOrder(2 * index + 1);
            }
            //向右递归遍历
            if (2 * index + 2 < array.Length)
            {
                PreOrder(2 * index + 2);
            }
        }
    }
}
