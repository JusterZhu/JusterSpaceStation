namespace SemaphoreDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// 创建一个具有最大计数 3 和初始计数 0 的命名 Semaphore
            //Semaphore semaphore = new Semaphore(0, 3, "MySemaphore");

            //// 允许三个线程或进程访问资源
            //semaphore.Release(3);

            //// ... 进行其他工作 ...

            //// 不再需要 Semaphore 时关闭它
            //semaphore.Close();

            //// 在另一个进程中打开已经存在的命名 Semaphore
            //Semaphore existingSemaphore;
            //try
            //{
            //    existingSemaphore = Semaphore.OpenExisting("MySemaphore");
            //}
            //catch (System.Threading.WaitHandleCannotBeOpenedException)
            //{
            //    Console.WriteLine("The named semaphore does not exist.");
            //    return;
            //}

            //// 尝试进入 semaphore. 如果计数器大于零，则成功并将计数器减一
            //existingSemaphore.WaitOne();

            //// ... 进行工作 ...

            //// 完成工作后，释放访问权，以便其他等待的线程或进程可以进入
            //existingSemaphore.Release();

            //// ... 进行其他工作 ...

            //// 不再需要 Semaphore 时关闭它
            //existingSemaphore.Close();

            Task.Run(async() =>
            {
                SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

                List<Task> tasks = new List<Task>();

                for (int i = 0; i < 10; i++)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        await semaphore.WaitAsync();

                        try
                        {
                            // Critical section.
                            Console.WriteLine("Task {0} in critical section.", Task.CurrentId);
                            await Task.Delay(1000); // Simulate some work.
                        }
                        finally
                        {
                            Console.WriteLine("Task {0} leaving critical section.", Task.CurrentId);
                            semaphore.Release();
                        }
                    }));
                }

                await Task.WhenAll(tasks);
            });
             Console.Read();
        }
    }
}
