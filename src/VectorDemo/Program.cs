namespace VectorDemo
{
    using System;
    using System.Numerics;
    using System.Diagnostics;

    public class Program
    {
        public static void Main()
        {
            int size = 1000000;
            float[] arrayA = new float[size];
            float[] arrayB = new float[size];
            float[] result = new float[size];

            // 初始化数据
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                arrayA[i] = (float)rand.NextDouble();
                arrayB[i] = (float)rand.NextDouble();
            }

            // 使用普通循环进行向量加法操作，并统计耗时
            Stopwatch normalLoopTimer = new Stopwatch();
            normalLoopTimer.Start();

            for (int i = 0; i < size; i++)
            {
                result[i] = arrayA[i] + arrayB[i];
            }

            normalLoopTimer.Stop();

            // 使用Vector进行向量加法操作，并统计耗时
            Stopwatch vectorTimer = new Stopwatch();
            vectorTimer.Start();

            for (int i = 0; i < size; i += Vector<float>.Count)
            {
                Vector<float> vectorA = new Vector<float>(arrayA, i);
                Vector<float> vectorB = new Vector<float>(arrayB, i);
                Vector<float> resultVector = Vector.Add(vectorA, vectorB);
                resultVector.CopyTo(result, i);
            }

            vectorTimer.Stop();

            Console.WriteLine($"普通循环耗时：{normalLoopTimer.ElapsedMilliseconds} 毫秒");
            Console.WriteLine($"使用Vector优化耗时：{vectorTimer.ElapsedMilliseconds} 毫秒");
        }
    }

}
