namespace ParallelDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 100);

            Parallel.ForEach(numbers, number =>
            {
                Console.WriteLine(number);
            });
            Console.Read();
        }
    }
}
