namespace PathDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullPath = @"C:\temp\example.txt";
            string suffix = "_suffix";

            string dirName = Path.GetDirectoryName(fullPath); // 获取目录名 
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullPath); // 获取没有扩展名的文件名
            string extension = Path.GetExtension(fullPath); // 获取扩展名

            string newFullPath = Path.Combine(dirName, fileNameWithoutExtension + suffix + extension);

            // 输出：C:\temp\example_suffix.txt
            Console.WriteLine(newFullPath);
        }
    }
}
