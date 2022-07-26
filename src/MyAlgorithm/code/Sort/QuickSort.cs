using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Sort
{
    public class QuickSort
    {
        public static void Sort(int[] arr,int left,int right) 
        {
            int l = left; //左下标
            int r = right; //右下标
            int pivot = arr[(left + right) / 2];
            int temp = 0;//临时变量，作为交换时使用
            //while循环的目的是让比pivot值小的放到左边
            //比pivot值大的放到右边
            while (l < r)
            {
                //在pivot的左边一直找，找到大于等于pivot值才推出
                while (arr[l] < pivot)
                    l += 1;
                
                //在pivot的右边一直找，找到大于等于pivot值才推出
                while (arr[r] > pivot)
                    r -= 1;

                //如果l>=r说明pivot的左右两边的值，已经按照左边全部是小于等于
                //pivot值，而右边全部是大于等于pivot的值
                if (l >= r) break;

                //交换
                temp = arr[l];
                arr[l] = arr[r];
                arr[r] = temp;

                //如果交换完后，发现这个arr[l] == pivot值相等，r-- 前移
                if (arr[l] == pivot) r -= 1;

                //如果交换完后，发现这个arr[r] == pivot值相等，l++ 后移
                if (arr[r] == pivot) l += 1;
            }

            //如果l == r,必须l++,r--,否则为出现栈溢出
            if (l == r)
            {
                l += 1;
                r -= 1;
            }

            //左递归
            if (left < r) Sort(arr, left, r);

            //右递归
            if (l < right) Sort(arr, l, right);

            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
