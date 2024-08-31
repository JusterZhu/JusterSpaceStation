using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
 
namespace SFTPDemo
{
    internal class SFTPManage
    {
        const int Port = 22;
        const string Host = "192.168.1.254";
        const string User = "zhuzhen";
        const string Password = "123456789";
        
        public void GetFiles()
        {
            using (var client = new SftpClient(Host, Port, User, Password))
            {
                client.Connect();
                var files = client.ListDirectory("D:/");
                foreach (var file in files)
                {
                    Console.WriteLine(file.Name);
                }
                client.Disconnect();
            }
        }
    }
}
