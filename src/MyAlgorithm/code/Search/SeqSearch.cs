using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Search
{
    /// <summary>
    /// 线性查找
    /// </summary>
    public class SeqSearch
    {
        public static int Search(int[] arr,int value) 
        {
            //逐一比对，发现有相同值时返回下标
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
