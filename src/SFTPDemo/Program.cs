namespace SFTPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SFTPManage manage = new SFTPManage();
            manage.GetFiles();
            Console.Read();
        }
    }
}
