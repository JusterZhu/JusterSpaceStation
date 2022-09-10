using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.DAC
{
    /// <summary>
    /// DAC----分治（Divide-and-conquer(P)）
    /// Hanoitower ---- 汉诺塔
    /// </summary>
    public class Hanoitower
    {
        public static void Move(int num, char a, char b, char c) 
        {
            //如果只有一个盘
            if (num == 1)
            {
                Console.WriteLine($"第1个盘从{a} -> {c}");
            }
            else
            {
                //如果我们有n>=2情况，我们总是可以看做是两个盘1.最下面的盘 2.最上面的盘
                //1.先把最上面的盘A->B，移动过程会使用到C
                Move(num - 1, a, c, b);
                //2.把最下边的盘A->C
                Console.WriteLine($"第{num}个盘从{a} -> {c}");
                //3.把B塔的所有盘从B->C，移动过程会使用到A
                Move(num - 1, b, a, c);
            }
        }
    }
}
