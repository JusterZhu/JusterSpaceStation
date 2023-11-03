using System.Transactions;

namespace TransactionScopeDemo
{
    internal class Program
    {
        // 定义两个要写入文件的路径
        static string path1 = @"C:\temp\file1.txt";
        static string path2 = @"C:\temp\file2.txt";

        static void Main(string[] args)
        {
            using (var t = new FileSystemTransaction("My Transaction"))
            {
                try
                {
                    // 执行文件操作
                    // ...
                    PerformTransaction();
                    t.Commit();
                }
                catch (Exception)
                {
                    t.Rollback();
                }
                finally
                {
                    // 检查文件是否存在
                    Console.WriteLine($"Is {path1} exists? {File.Exists(path1)}");
                    Console.WriteLine($"Is {path2} exists? {File.Exists(path2)}");
                }
            }

            Console.Read();
        }

        public static void PerformTransaction()
        {
            // 写入第一个文件
            File.WriteAllText(path1, "Hello, world!");
            // 写入第二个文件
            File.WriteAllText(path2, "Welcome to C#!");
            throw new Exception();
        }
    }
}
