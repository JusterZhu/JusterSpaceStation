namespace ThreadLocalDemo;

class Program
{
    // 定义一个线程本地变量
    private static ThreadLocal<int> _threadLocalData = new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);
    
    static void Main(string[] args)
    {
        // 启动多个线程，每个线程都会访问自己的线程本地数据
        Thread[] threads = new Thread[3];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() =>
            {
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}, ThreadLocal Value: {_threadLocalData.Value}");
            });
            threads[i].Start();
        }

        // 等待所有线程执行完毕
        foreach (Thread t in threads)
        {
            t.Join();
        }

        Console.Read();
    }
}

/*class Program
{
    [ThreadStatic]
    private static int _threadStaticData;

    static void Main()
    {
        Thread[] threads = new Thread[3];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() =>
            {
                _threadStaticData = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}, ThreadStatic Value: {_threadStaticData}");
            });
            threads[i].Start();
        }

        foreach (Thread t in threads)
        {
            t.Join();
        }
    }
}*/

/*class Program
{
    static LocalDataStoreSlot slot = Thread.AllocateDataSlot();

    static void Main()
    {
        Thread thread1 = new Thread(new ThreadStart(ThreadMethod));
        Thread thread2 = new Thread(new ThreadStart(ThreadMethod));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }

    static void ThreadMethod()
    {
        Thread.SetData(slot, $"Data for {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine(Thread.GetData(slot));
    }
}*/

/*class Program
{
    private static AsyncLocal<string> asyncLocalValue = new AsyncLocal<string>(args =>
    {
        Console.WriteLine($"Value changed: {args.PreviousValue} -> {args.CurrentValue}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
    });

    static async Task Main(string[] args)
    {
        asyncLocalValue.Value = "Initial Value";
        Console.WriteLine($"Main Method: {asyncLocalValue.Value}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");

        await Task.Run(() =>
        {
            Console.WriteLine($"Task 1 Start: {asyncLocalValue.Value}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            asyncLocalValue.Value = "Task 1 Value";
            Console.WriteLine($"Task 1 End: {asyncLocalValue.Value}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        });

        Console.WriteLine($"Main Method After Task 1: {asyncLocalValue.Value}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");

        await Task.Run(() =>
        {
            Console.WriteLine($"Task 2 Start: {asyncLocalValue.Value}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            asyncLocalValue.Value = "Task 2 Value";
            Console.WriteLine($"Task 2 End: {asyncLocalValue.Value}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        });

        Console.WriteLine($"Main Method After Task 2: {asyncLocalValue.Value}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
    }
}*/