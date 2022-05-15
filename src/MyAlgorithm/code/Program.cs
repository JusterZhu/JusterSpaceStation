using MyAlgorithm.Graph;
using MyAlgorithm.Search;
using MyAlgorithm.Tree;
using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //初始化一个有序的100长度的数组
            int[] arr = new int[100];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
            //使用二分查找，并在方法内部加一个打印，输出几次代表执行了几次
            var result = BinarySearch.Search(arr,0,arr.Length,99);
            Console.WriteLine(result);
            //使用插值查找，并在方法内部加一个打印，输出几次代表执行了几次
            var result0 = InsertValueSearch.Search(arr, 0,arr.Length -1 , 99);
            Console.WriteLine(result0);
            Console.Read();
        }
    }
}
