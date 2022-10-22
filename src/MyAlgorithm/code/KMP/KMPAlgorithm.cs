using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.KMP
{
    public class KMPAlgorithm
    {
        //string str1 = "BBD ABCDAB ABCDABCDABDE";
        //string str2 = "ABCDABD";

        /// <summary>
        /// KMP搜索算法
        /// </summary>
        /// <param name="str1">源字符串</param>
        /// <param name="str2">子串</param>
        /// <param name="next">部分匹配表，是子串对应的部分匹配表</param>
        /// <returns>如果是-1就是没有匹配到，否则返回第一个匹配的位置</returns>
        public static int KMPSearch(string str1,string str2, int[] next) 
        {
            //遍历
            for (int i = 0, j = 0; i < str1.Length; i++)
            {
                //需要考虑(str1[i] != str2[j])
                while (j > 0 && str1[i] != str2[j])
                {
                    j = next[j - 1];
                }

                if (str1[i] == str2[j])
                {
                    j++;
                }

                if (j == str2.Length)
                {
                    return i - j + 1;
                }
            }
            return -1;
        }

        //获取到一个字符串（子串）的部分匹配值。
        public static int[] KMPNext(string dest) 
        {
            //创建一个next数组保存部分匹配值
            int[] next = new int[dest.Length];
            next[0] = 0;//如果字符串长度是长度为1部分匹配值就是0
            for (int i = 1,j=0; i < dest.Length; i++)
            {
                //当dest[i] != dest[j]满足时，我们需要从next[j-1]获取新的j
                //直到我们发现有dest[i] == dest[j]成立退出
                while (j > 0 && dest[i] != dest[j])
                {
                    j = next[j - 1];
                }

                //当dest[i] == dest[j]满足时，部分匹配值就需要+1
                if (dest[i] == dest[j])
                {
                    j++;
                }
                next[i] = j;
            }
            return next;
        }
    }
}
