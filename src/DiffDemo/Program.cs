namespace DiffDemo;

class Program
{
    static void Main(string[] args)
    {
        string dirA = @"D:\Program Files\Tencent\QQNTbakA";
        string dirB = @"D:\Program Files\Tencent\QQNTbakB";

        var uniqueToA = new List<string>();
        var uniqueToB = new List<string>();
        var differentFiles = new List<string>();

        MyDiff.CompareDirectories(dirA, dirB, uniqueToA, uniqueToB, differentFiles);

        Console.WriteLine("Files unique to A:");
        uniqueToA.ForEach(Console.WriteLine);

        Console.WriteLine("\nFiles unique to B:");
        uniqueToB.ForEach(Console.WriteLine);

        Console.WriteLine("\nDifferent files:");
        differentFiles.ForEach(Console.WriteLine);
        
        Console.Read();
    }
}