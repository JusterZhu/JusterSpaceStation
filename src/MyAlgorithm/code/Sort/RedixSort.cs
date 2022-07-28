using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Sort
{
    public class RedixSort
    {
        public static void Sort(int[] arr) 
        {
            //根据前面的推导过程，我们可以得到最终的基数排序代码

            //1.得到数组中最大的位数
            int max = arr[0];//假设第一个数就是最大的
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            //得到最大数是几位
            int maxLength = (max + "").Length;

            //定义一个二维数组，表示10个桶，每个桶就是一个一维数组
            //说明
            //1. 二维数组包含10个一维数组
            //2. 为了防止在放入的时候，数据溢出，则每个一维数组（桶），大小定位arr.length
            //3.明确，基数排序是使用空间换时间的经典排序算法
            int[,] bucket = new int[10,arr.Length];

            //为了记录每个桶中，实际存放了多少个数据，我们定义一个一维数组来记录各个桶的每次放入的数据个数
            //可以这样理解
            //比如：bucketElementCounts[0],记录的就是bucket[0]桶的放入数据的个数
            int[] bucketElementCounts = new int[10];

            for (int i = 0, n = 1; i < maxLength; i++,n *= 10)
            {
                //针对每个元素的对应位进行排序处理，第一次是个位，第二次是十位，第三次是百位...
                for (int j = 0; j < arr.Length; j++)
                {
                    //取出每个元素的个数
                    int digitOfElement = arr[j] / n % 10;
                    //放入到对应的桶中
                    bucket[digitOfElement, bucketElementCounts[digitOfElement]] = arr[j];
                    bucketElementCounts[digitOfElement]++;
                }
                //按照这个桶的顺序（一维数组的下标依次取出数据，放入原来数组）
                int index = 0;
                //遍历每一通，并将桶中的数据，放到原数组中
                for (int k = 0; k < bucketElementCounts.Length; k++)
                {
                    //如果桶中，有数据，我们才放入到原数组
                    if (bucketElementCounts[k] != 0)
                    {
                        //循环该桶的第k个桶（即第k个一维数组），放入
                        for (int l = 0; l < bucketElementCounts[k]; l++)
                        {
                            //取出元素放入到arr中
                            arr[index++] = bucket[k, l];
                        }
                    }
                    //第i+1轮处理后，需要将每个bucketElementCounts[k]=0
                    bucketElementCounts[k] = 0;
                }
                //Console.WriteLine(string.Join(' ', arr));
            }
        }
    }
}
