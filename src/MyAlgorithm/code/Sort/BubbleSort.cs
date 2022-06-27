using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Sort
{
    public class BubbleSort
    {
        public static void Sort(int[] array) 
        {
            //临时变量
            int temp = 0;
            //标识变量，表示是否进行过交换
            bool flag = false;
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    //如果前面的数比后面的数大，则交换
                    if (array[j] > array[j + 1])
                    {
                        flag = true;
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }

                //在一趟排序中，一次交换都没有发生过则直接break
                if (!flag) 
                {
                    break;
                }
                else 
                {
                    //充值flag，进行下次判断
                    flag =false;
                }
                Console.WriteLine(string.Join(' ', array));
            }
        }

        public static void Sort0(int[] array)
        {
            //临时变量
            int temp = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    //如果前面的数比后面的数大，则交换
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
                Console.WriteLine(string.Join(' ', array));
            }
        }
    }
}
