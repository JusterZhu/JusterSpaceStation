using System.Diagnostics;

namespace OptimisticPessimistic
{
    internal class Program
    {
        #region 悲观锁

        //static Entity sharedEntity = new Entity(1, "SharedResource");

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Starting updates...");

        //    Task t1 = Task.Run(() => UpdateEntity("Thread 1", 2));
        //    Task t2 = Task.Run(() => UpdateEntity("Thread 2", 3));
        //    Task t3 = Task.Run(() => UpdateEntity("Thread 3", 1));

        //    Task.WaitAll(t1, t2,t3);

        //    Console.WriteLine("Updates completed.");
        //    Console.WriteLine($"Final Entity Version: {sharedEntity.Version}");
        //}

        //static void UpdateEntity(string threadName, int newVersion)
        //{
        //    Console.WriteLine($"{threadName} is updating the resource.");

        //    // Simulate some work
        //    Thread.Sleep(1000);

        //    // Attempt to update the resource
        //    lock (sharedEntity)
        //    {
        //        Console.WriteLine("ThreadName:" + threadName + ",sharedEntity.Version" + sharedEntity.Version);
        //        Console.WriteLine("ThreadName:" + threadName + ",newVersion" + newVersion);
        //        if (sharedEntity.Version == newVersion)
        //        {
        //            // Perform the update
        //            sharedEntity.Name = $"{threadName} updated the resource.";
        //            sharedEntity.Version++;

        //            Console.WriteLine($"{threadName} updated the resource successfully.");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"{threadName} encountered a version conflict.");
        //        }
        //    }
        //}

        #endregion

        #region 乐观锁

        private static int sharedValue = 0;
        private static int version = 0;

        static void Main(string[] args)
        {
            // 模拟两个线程尝试同时更新共享值
            Task t1 = Task.Run(() => UpdateSharedValue(1));
            Task t2 = Task.Run(() => UpdateSharedValue(2));

            Task.WaitAll(t1, t2);

            Console.WriteLine($"Final Shared Value: {sharedValue}");
        }

        static void UpdateSharedValue(int id)
        {
            int localVersion;

            localVersion = Interlocked.CompareExchange(ref version, 0, 0); // 获取当前版本号

            Console.WriteLine($"Thread {id}: Current Version: {localVersion}");

            // 模拟一些计算或操作
            Thread.Sleep(100);

            // 检查版本是否仍然匹配
            if (localVersion == version)
            {
                Interlocked.Increment(ref sharedValue); // 更新共享值
                Interlocked.Increment(ref version); // 增加版本号
                Console.WriteLine($"Thread {id}: Value Updated. New Value: {sharedValue}, New Version: {version}");
            }
            else
            {
                Console.WriteLine($"Thread {id}: Update Failed due to version mismatch.");
            }
        }

        #endregion
    }
}