using System.Diagnostics;

namespace PerformanceCounter;

class Program
{
    static void Main(string[] args)
    {
        // 检查性能计数器类别是否存在
        if (!PerformanceCounterCategory.Exists("MyCategory"))
        {
            // 创建性能计数器类别
            CounterCreationDataCollection counters = new CounterCreationDataCollection();

            // 创建一个性能计数器
            CounterCreationData myCounter = new CounterCreationData();
            myCounter.CounterName = "MyCounter";
            myCounter.CounterType = PerformanceCounterType.NumberOfItems32;
            counters.Add(myCounter);

            // 创建类别
            PerformanceCounterCategory.Create("MyCategory",
                "Sample Category",
                PerformanceCounterCategoryType.SingleInstance,
                counters);
        }

        // 创建和初始化性能计数器
        System.Diagnostics.PerformanceCounter counter = new System.Diagnostics.PerformanceCounter("MyCategory", "MyCounter", false);
        counter.RawValue = 0;

        // 增加计数器的值
        for (int i = 0; i < 10; i++)
        {
            counter.Increment();
            Console.WriteLine("Counter Value: " + counter.RawValue);
            Thread.Sleep(1000);
        }

        Console.Read();
    }
}