using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace SFTDemo2
{
    internal class SFTPManage
    {
        internal void Test() 
        {
            // 设置会话选项
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = "192.168.1.254", // 服务器地址
                UserName = "zhuzhen", // 用户名
                Password = "123456789", // 密码
                SshHostKeyFingerprint = "ssh-rsa 2048 tX+GJ5ArF+E6UpBs15dQcKQTrxeXAaom2ApxnSJpLfo"
            };

            using (Session session = new Session())
            {
                // 连接到服务器
                session.Open(sessionOptions);

                // 指定远程目录路径
                string remotePath = "C:\\SftpRoot";

                // 获取指定目录下的文件列表
                RemoteDirectoryInfo directoryInfo = session.ListDirectory(remotePath);

                // 打印出所有文件名
                foreach (RemoteFileInfo fileInfo in directoryInfo.Files)
                {
                    Console.WriteLine("Name: {0}", fileInfo.Name);
                }
            }
        }
    }
}
