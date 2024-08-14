namespace NamedPipeService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PipeServer pipeServer = new PipeServer();
            pipeServer.StartServer();
            Console.Read();
        }
    }
}
