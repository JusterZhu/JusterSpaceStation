using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlgorithm.Recursion
{
    /// <summary>
    /// 递归
    /// </summary>
    internal class MyRecursion
    {
        public void Print(int n) 
        {
            if (n > 2) 
            {
                Print(n - 1);
            }
            Console.WriteLine("n=" + n);
        }

        public int Factorial(int n) 
        {
            if (n == 1)
            {
                return 1;
            }
            else 
            {
                return Factorial(n - 1) * n;
            }
        }
    }
}
