namespace NamedPipeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PipeClient pipeClient = new PipeClient();
            pipeClient.StartClient();
            Console.Read();
        }
    }
}
