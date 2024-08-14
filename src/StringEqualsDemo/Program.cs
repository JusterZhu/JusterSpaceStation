namespace StringEqualsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Zhangsan";
            string str2 = "ZHANGsaN";
            Console.WriteLine(str1 == str2);
            Console.WriteLine(str1.Equals(str2));
            Console.WriteLine(string.Equals(str1,str2,StringComparison.OrdinalIgnoreCase));
        }
    }
}
