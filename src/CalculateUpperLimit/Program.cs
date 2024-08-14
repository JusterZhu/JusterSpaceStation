namespace CalculateUpperLimit;

class Program
{
    static void Main(string[] args)
    {
        var result = CalculateUpperLimit(3580);
        Console.WriteLine(result);
        Console.Read();
    }
    
    private static int CalculateUpperLimit(int num)
    {
        int digitsCount = (int)Math.Log10(num) + 1;
        return (int)Math.Pow(10, digitsCount);
    }
}