using System.Diagnostics;

namespace MemoizeDemo
{
    internal class Program
    {
        private static Dictionary<int, long> cache = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            //Func<int, int> slowFunction = x =>
            //{
            //    // some expensive computation
            //    System.Threading.Thread.Sleep(1000);
            //    return x * x;
            //};

            //var memoizedSlowFunction = slowFunction.Memoize();

            //Stopwatch stopwatch = new Stopwatch();

            //stopwatch.Start();
            //Console.WriteLine(memoizedSlowFunction(25));
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
            //stopwatch.Reset();

            //stopwatch.Start();
            //Console.WriteLine(memoizedSlowFunction(25));
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

            //Func<int, long> fib = null;
            //fib = n => n > 1 ? fib(n - 1) + fib(n - 2) : n;

            //var memoizedFib = fib.Memoize3();

            //Stopwatch stopwatch = new Stopwatch();

            //stopwatch.Start();
            //Console.WriteLine(memoizedFib(40));
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
            //stopwatch.Reset();

            //stopwatch.Start();
            //Console.WriteLine(memoizedFib(39));
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

            Memoizer<int, long> memoizer = null;
            memoizer = new Memoizer<int, long>(n => Fibonacci(n, memoizer));

            var result = memoizer.Get(10);  // 这会计算第10个斐波那契数
            Console.WriteLine(result);
        }

        public static long Fibonacci(int n, Memoizer<int, long> memoizer)
        {
            if (n < 2)
                return n;

            // 使用记忆化来保存计算过的结果，防止重复计算
            return memoizer.Get(n - 1) + memoizer.Get(n - 2);
        }
    }
}
