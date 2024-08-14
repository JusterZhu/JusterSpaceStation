namespace FileComparerDiffDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var comparer = new FileComparer("D:\\test\\packetA", "D:\\test\\packetB");

            var missingFiles = comparer.GetFilesInBNotInA();

            foreach (var file in missingFiles)
            {
                Console.WriteLine($"文件 {file} 在目录 A 中没有找到");
            }
            Console.Read();
        }
    }
}
