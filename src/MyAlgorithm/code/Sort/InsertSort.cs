using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Sort
{
    public class InsertSort
    {
        public static void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                //定义待插入的数
                int insertVal = arr[i];
                //即arr[1]的前面这个数的下标
                int insertIndex = i - 1;
                //给insertval找到插入的位置
                //1.insertindex >0 保证在给 insertval找到插入位置，不越界
                //2.insertVal < arr[insertIndex] 待插入的数，还没有找到插入位置
                //3.就需要将arr[insertIndex]后移
                while (insertIndex >= 0 && insertVal < arr[insertIndex])
                {
                    arr[insertIndex + 1] = arr[insertIndex];
                    insertIndex--;
                }
                //当推出while循环时，说明插入的位置找到，insertindex+1
                //举例：
                arr[insertIndex + 1] = insertVal;
                Console.WriteLine(string.Join(' ', arr));
            }
        }
    }
}
