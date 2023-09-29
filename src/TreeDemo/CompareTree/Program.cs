using ClassLibrary1;
using ClassLibrary1.MyTree;

namespace CompareTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FileNode> fileNodes = new List<FileNode>();
            FileProvider fileProvider = new FileProvider();
            fileProvider.Compare("F:\\temp\\work1", "F:\\temp\\work2",ref fileNodes);
            Console.Read();
        }
    }
}