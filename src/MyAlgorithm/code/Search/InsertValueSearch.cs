using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Search
{
    public class InsertValueSearch
    {
        /// <summary>
        /// 插值查找算法(需要数组是有序的)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left">左边索引</param>
        /// <param name="right">右边索引</param>
        /// <param name="findval">查找值</param>
        /// <returns>值的下标</returns>
        public static int Search(int[] arr, int left,int right,int findval)
        {
            Console.WriteLine("InsertValueSearch");
            //必须需要，否则得到的mid的值可能越界。
            if (left > right || findval < arr[0] || findval > arr[arr.Length - 1])
            {
                return -1;
            }
            //求出mid
            int mid = left + (right - left) * (findval - arr[left]) / (arr[right] - arr[left]);
            int midVal = arr[mid];
            if (findval > midVal)
            {
                //说明应该向右边进行查找
                return Search(arr, mid + 1, right, findval);
            }
            else if (findval < midVal)
            {
                return Search(arr, left, mid - 1, findval);
            }
            else
            {
                return mid;
            }
        }
    }
}
