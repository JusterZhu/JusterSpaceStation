using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Search
{
    public class FibonacciSearch
    {
        public static int MaxSize = 20;

        //因为后面我们mid=low + F(k-1)-1, 需要使用到斐波那契数列，因此我们需要先获取到一个斐波那契数列
        //非递归方式得到一个斐波那契数列

        public static int[] Fib() 
        {
            int[] fibArray = new int[MaxSize];
            fibArray[0] = 1;
            fibArray[1] = 1;
            for (int i = 2; i < MaxSize; i++)
            {
                fibArray[i] = fibArray[i - 1] + fibArray[i - 2];
            }
            return fibArray;
        }

        /// <summary>
        /// 斐波那契查找算法
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="key">我们需要查找的关键码值</param>
        /// <returns>下标，没找到为-1</returns>
        public static int Search(int[] array, int key) 
        {
            int low = 0;
            int high = array.Length - 1;
            int k = 0; // 表示斐波那契分割数值的下标
            int mid = 0;//存放mid值
            int[] fibArray = Fib();//获取到斐波那契数列
            //获取到斐波那契分割数值的下标
            while (high > fibArray[k] - 1)
            {
                k++;
            }
            //因为f[k]可能大于数组array的长度，因此我们需要构造一个新的数组，并指向temp[]
            //不足的部分用0代替
            int[] temp = new int[fibArray[k]];
            Array.Copy(array, temp, array.Length);
            //实际上需求使用a数组最后的数填充temp
            for (int i = high + 1; i < temp.Length; i++ )
            {
                temp[i] = array[high];
            }
            //使用while循环来处理，找到我们的key
            while (low <= high)
            {
                //只要这个条件满足，就可以找
                mid = low + fibArray[k - 1] - 1;
                if (key < temp[mid])
                {
                    //说明我们应该继续向数组的前面查找（左边）
                    high = mid - 1;
                    //为什么是k--
                    //1.全部元素 = 前面的元素 + 后面的元素
                    //2.fibarray[k] = fibarray[k - 1] + fibarray[k -2];
                    //因为前面有fibarray[k-1]元素，所以可以继续拆分fibarray[k-1] = fibarray[k-2]+fibarray[k-3];
                    //即在fibarray[k-1]的前面继续查找k--
                    //即下次循环mid = fibarray[k-1-1]-1 
                    k--;
                }
                else if(key > temp[mid])
                {
                    //我们应该继续向数组的后面查找（右边）
                    low = mid + 1;
                    //为什么是k -=2
                    //说明
                    //1.全部元素 = 前面的元素 + 后面的元素
                    //因为后面有fibarray[k-2]元素，所以可以继续拆分fibarray[k-1] = fibarray[k-3]+fibarray[k-4];
                    //即在fibarray[k-2]的前面继续查找k-=2
                    //即下次循环mid = fibarray[k-1-2]-1 
                    k -= 2;
                }
                else
                {
                    //找到了，需要确定返回的是哪个下标
                    if (mid <= high)
                    {
                        return mid;
                    }
                    else
                    {
                        return high;
                    }
                }
            }
            return -1;
        }
    }
}
