using System;

namespace MyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = Factorial(4);
            Console.WriteLine(result);
        }

        public static int Factorial(int n)
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
