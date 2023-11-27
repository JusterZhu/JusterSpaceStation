using System;
using System.IO;
using System.IO.Pipes;

namespace NamedPipeService
{
    public class PipeServer
    {
        public void StartServer()
        {
            using (NamedPipeServerStream pipeServer =
                new NamedPipeServerStream("testpipe", PipeDirection.InOut))
            {
                Console.WriteLine("Waiting for connection....");
                pipeServer.WaitForConnection();

                try
                {
                    using (StreamReader sr = new StreamReader(pipeServer))
                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;
                        string inputFromClient;

                        while ((inputFromClient = sr.ReadLine()) != null)
                        {
                            Console.WriteLine($"Received from client: {inputFromClient}");
                            // Send the same message back to client as an echo.
                            sw.WriteLine(inputFromClient);
                            Console.WriteLine($"Sent back to client: {inputFromClient}");
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
