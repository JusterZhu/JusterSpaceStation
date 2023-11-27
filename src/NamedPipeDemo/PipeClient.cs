using System;
using System.IO;
using System.IO.Pipes;


namespace NamedPipeDemo
{
    public class PipeClient
    {
        public void StartClient()
        {
            using (NamedPipeClientStream pipeClient =
                new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut))
            {
                pipeClient.Connect();
                Console.WriteLine("Connected to server....");

                try
                {
                    using (StreamReader sr = new StreamReader(pipeClient))
                    using (StreamWriter sw = new StreamWriter(pipeClient))
                    {
                        while (true) 
                        {
                            sw.AutoFlush = true;
                            string inputFromUser = Console.ReadLine();
                            sw.WriteLine(inputFromUser);

                            string responseFromServer = sr.ReadLine();
                            Console.WriteLine($"Response from server: {responseFromServer}");
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.Error.WriteLine($"Error: {e.Message}");
                }
            }
        }
    }

}
