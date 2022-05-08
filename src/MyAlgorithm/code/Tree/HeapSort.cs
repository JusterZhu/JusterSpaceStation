using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Tree
{
    public class HeapSort
    {
        public static void HeapSort0(int[] arr)
        {
            int temp = 0;
            Console.WriteLine("堆排序！");
            //分步完成
            //AddJustHeap(arr, 1, arr.Length);
            //Console.WriteLine("第一次" + string.Join(' ',arr));//4,9,8,5,6

            //AddJustHeap(arr, 0, arr.Length);
            //Console.WriteLine("第二次" + string.Join(' ', arr));//9,6,8,5,4

            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                AddJustHeap(arr, i, arr.Length);
            }
            //Console.WriteLine("第三次" + string.Join(' ', arr));

            for (int j = arr.Length - 1; j > 0; j--)
            {
                temp = arr[j];
                arr[j] = arr[0];
                arr[0] = temp;
                AddJustHeap(arr, 0, j);
            }
            Console.WriteLine("数组=" + string.Join(' ', arr));
        }

        /// <summary>
        /// 完成将以i指向的对应的非叶子节点的树调整为一个大顶堆
        /// 将一个数组（二叉树），调整为一个大顶堆
        /// 举例int [] arr = {4,6,8,5,9}; =>i = 1 => addjustheap => 得到{ 4，9，8，5，6 }
        /// 如果我们再次调用addjustheap 传入的是i = 0 =>{4,9,8,5,6}=>{9,6,8,5,4}
        /// </summary>
        /// <param name="arr">待调整数组</param>
        /// <param name="i">表示非叶子节点在数组中索引</param>
        /// <param name="length">表示堆多少个元素进行继续调整，length在逐渐减少</param>
        public static void AddJustHeap(int[] arr, int i, int length)
        {
            int temp = arr[i];//先取数当前元素的值，保存在临时变量
            //开始调整
            //1. k = i * 2 + 1 , k 是i节点的左子节点
            for (int k = i * 2 + 1; k < length; k = k * 2 +1)
            {
                //说明左子节点的值小于又子节点的值
                if (k + 1 < length && arr[k] < arr[k+1])
                {
                    k++; // k指向又子节点
                }

                //如果子节点大于父节点
                if (arr[k] > temp)
                {
                    //把较大的值赋给当前节点
                    arr[i] = arr[k];
                    //i 指向 k，继续循环比较
                    i = k;
                }
                else
                {
                    break;
                }
            }
            //当for循环结束后，我们已经将以i为父节点的树的最大值，放在了最顶（局部）
            arr[i] = temp;//将temp的值放到调整后的位置
        }
    }
}
