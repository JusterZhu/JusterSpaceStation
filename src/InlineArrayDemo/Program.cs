namespace InlineArrayDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InlineArrayExample inlineArrayExample = new InlineArrayExample();
            //for (int i = 0; i < 10; i++)
            //{
            //    inlineArrayExample[i] = 1;
            //}
            foreach (var item in inlineArrayExample)
            {
                Console.WriteLine( item);
            }
        }
    }
}
