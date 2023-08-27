using System;
using System.Reflection;
using System.AddIn.Hosting;

namespace MAFDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        private static void Init() {
            string pipelinePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Pipeline");

            AddInStore.Update(pipelinePath);
        }
    }
}