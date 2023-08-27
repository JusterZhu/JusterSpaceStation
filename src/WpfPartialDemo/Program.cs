using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPartialDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IPacket packet = new Packet();
            packet.Head();
            packet.Body();
            packet.Foot();
            Console.Read();
        }
    }
}
