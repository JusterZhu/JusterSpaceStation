namespace SearchDirverDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mySearchDirver = new MySearchDirver();

            //string path = @"D:\packet\cache"; // 请将此替换为你要搜索的路径
            //List<string> directories = mySearchDirver.GetAllDriverDirectories(path);
            //foreach (var dir in directories)
            //{
            //    Console.WriteLine(dir);
            //}

            foreach (var item in mySearchDirver.GetUniqueFiles("D:\\packet\\source", "D:\\packet\\target"))
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
