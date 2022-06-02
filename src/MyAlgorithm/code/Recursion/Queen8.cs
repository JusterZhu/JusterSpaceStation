using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Recursion
{
    public class Queen8
    {
        //定义有多少个皇后棋子
        private const int max = 8;

        public static int count = 0;

        //保存皇后摆法的array，比如arr[8]={0,4,7,5,2,6,1,3}
        private int[] array = new int[max];

        /// <summary>
        /// 将皇后拜访的位置打印出来，可以将摆放的位置输出
        /// </summary>
        public void Print() 
        {
            //每当有一次正确解法count++
            count++;
            for (int i = 0; i < max; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 查看当我们放置第N个皇后，就去监测该皇后是否和前面已经摆放的皇后冲突
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool Judge(int n) 
        {
            for (int i = 0; i < n; i++)
            {
                //1.array[i] == array[n]表示判断第n个皇宫后是否和前面的n-1个皇后在同一列
                //2.Math.Abs(n - i) == Math.Abs(array[n] - array[i]) 表示判断是否在同一斜线
                //n = 1 放在第2列1 n =1  arr[1] = 1
                //Math.Abs(1 - 0) == 1 , Math.Abs(array[n] - array[i]) = Math.Abs(1 - 0)  = 1
                //3.判断是否在同一行，没有必要，n每次都在递增
                if (array[i] == array[n] || Math.Abs(n - i) == Math.Abs(array[n] - array[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 编写一个方法，放置第n个皇后
        /// 特别注意：check每一次递归时，进入到check种都有for循环操作，因此都会有回溯
        /// </summary>
        /// <param name="n"></param>
        public void Check(int n) 
        {
            if (n == max)
            {
                //n = 8 , 其实8个皇后已经放好了，九皇后就没必要操作了
                Print();
                return;
            }
            //依次放入皇后，并判断是否冲突
            for (int i = 0; i < max; i++)
            {
                //先把当前这个皇后n，放到该行的第1列
                array[n] = i;
                //当防止第n个皇后到i列时，是否冲突
                if (Judge(n))
                {
                    //如果不冲突，接着放n+1个皇后，即开始递归
                    Check(n + 1);
                }
                //如果冲突，就继续执行array[n] = i; 即将第n个皇后，放置在本行得后移一个位置
            }
        }
    }
}
