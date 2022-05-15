using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Search
{
    /// <summary>
    /// 二分查找算法
    /// </summary>
    public class BinarySearch
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="left">左边索引</param>
        /// <param name="right">右边索引</param>
        /// <param name="findval">需要查找的值</param>
        /// <returns>查找到的值下标，无就返回-1</returns>
        public static int Search(int[] arr,int left,int right,int findval) 
        {
            Console.WriteLine("BinarySearch");
            if (left > right)
            {
                return -1;
            }
            //当left > right时，说明整个数组没有找到
            int mid = (left + right) /2;
            int midval = arr[mid];
            if (findval > midval)
            {
                //向右递归
                return Search(arr, mid + 1, right, findval);
            }
            else if (findval < midval) 
            {
                //向左递归
                return Search(arr, left, mid - 1, findval);
            }
            else
            {
                return mid;
            }
        }

        public static List<int> Search0(int[] arr, int left, int right, int findval) 
        {
            if (left > right)
            {
                return new List<int>();
            }
            //当left > right时，说明整个数组没有找到
            int mid = (left + right) / 2;
            int midval = arr[mid];
            if (findval > midval)
            {
                //向右递归
                return Search0(arr, mid + 1, right, findval);
            }
            else if (findval < midval)
            {
                //向左递归
                return Search0(arr, left, mid - 1, findval);
            }
            else
            {
                List<int> resultIndexs =  new List<int>();
                //向mid索引值的左边扫描，将所有满足1000的元素的下标，加入到集合
                int temp = mid - 1;
                while (true) 
                {
                    if (temp < 0 || arr[temp] != findval)
                    {
                        break;
                    }
                    //否则就temp放入到list
                    resultIndexs.Add(temp);
                    //temp左移
                    temp -= 1;
                }
                //否则，就temp放入到list
                resultIndexs.Add(mid);

                temp = mid + 1;
                while (true)
                {
                    if (temp > arr.Length - 1 || arr[temp] != findval)
                    {
                        break;
                    }
                    //否则就temp放入到list
                    resultIndexs.Add(temp);
                    //temp左移
                    temp += 1;
                }
                return resultIndexs;
            }
        }
    }
}
