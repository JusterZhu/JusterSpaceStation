using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MyConditional
{
    public class TestClass2
    {
        public void Test() 
        {
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                //throw new Exception();
                Console.WriteLine("1");
            }
            //catch (Exception)
            //{
            //    Console.WriteLine("2");
            //}
            finally 
            {
                Test3.Go();
            }
        }

       
        public class Test3
        {
            static Test3() 
            {
                Console.WriteLine("123");
            }

            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            public static void Go() { }
        }
    }
}
