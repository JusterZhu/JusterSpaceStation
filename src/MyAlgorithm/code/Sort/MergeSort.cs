using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Sort
{
    public class MergeSort
    {
        //分+合方法
        public static void Sort(int[] arr, int left, int right, int[] temp) 
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                //向左递归进行分解
                Sort(arr,left,mid,temp);
                //向右递归进行分解
                Sort(arr, mid + 1, right, temp);
                //每分解一次就合并一次
                Merge(arr,left, mid, right, temp);
            }
        }

        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="arr">排序的原始数组</param>
        /// <param name="left">左边有序序列</param>
        /// <param name="mid">中间索引</param>
        /// <param name="right">右边有序序列</param>
        /// <param name="temp">中转数组</param>
        public static void Merge(int[] arr,int left,int mid,int right, int[] temp) {
            int i = left;//初始化i，左边有序序列的初始索引
            int j = mid + 1;//初始化j，右边有序序列的初始索引
            int t = 0;//指向temp数组的当前索引

            //1
            //先把左右两边（有序）的数据按照规则填充到temp数组
            //直到左右两边有序序列，又一遍处理完毕为止
            while (i <= mid && j <= right) {
                //如果左边的有序序列的当前元素，小于等于邮编的有序序列的当前元素
                //即将左边的当前元素，拷贝到temp数组
                //然后t++  i++
                if (arr[i] <= arr[j])
                {
                    temp[t] = arr[i];
                    t += 1;
                    i += 1;
                }
                else
                {
                    //如果右边的有序序列的当前元素，大于邮编的有序序列的当前元素
                    //即将右边的当前元素，拷贝到temp数组
                    //然后t++  j++
                    temp[t] = arr[j];
                    t += 1;
                    j += 1;
                }
            }

            //2
            //把有剩余数据的一遍的数据一次全部填充到temp
            while (i<=mid)
            {
                //左边的有序序列还有剩余的元素，就全部填充到temp
                temp[t] = arr[i];
                t += 1;
                i += 1;
            }
            while (j <= right)
            {
                //右边的有序序列还有剩余的元素，就全部填充到temp
                temp[t] = arr[j];
                t += 1;
                j += 1;
            }
            //3
            //将temp数组的元素拷贝到arr
            t = 0;
            int tempLeft = left;
            while (tempLeft <= right)
            {
                //第一次合并tempLeft = 0，right = 1 tempLeft = 2 right=3 t=0 tL=0 ri=3
                //最后一次tempLeft=0 right=7
                arr[tempLeft] = temp[t];
                t += 1;
                tempLeft += 1;
            }
        }
    }
}
