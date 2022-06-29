using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Sort
{
    public class SelectSort
    {
        public static void Sort(int[] array) 
        {
            for (int i = 0; i < array.Length -1; i++)
            {
                //使用逐步推导的方式来进行选择排序
                int minIndex = i;
                int min = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (min > array[j])
                    {
                        min = array[j];
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    //将最小值，挡在array[0]，即交换
                    array[minIndex] = array[i];
                    array[i] = min;
                }
                Console.WriteLine($"第{ i + 1 }轮排序后！");
                Console.WriteLine(string.Join(' ', array));
            }
        }
    }
}
