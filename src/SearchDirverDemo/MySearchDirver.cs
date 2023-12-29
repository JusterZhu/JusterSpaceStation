using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SearchDirverDemo
{
    internal class MySearchDirver
    {
        // 获取包含驱动文件的目录
        public List<string> GetAllDriverDirectories(string path)
        {
            HashSet<string> driverDirectories = new HashSet<string>();
            try
            {
                foreach (string filePath in Directory.GetFiles(path))
                {
                    if (IsDriverFile(filePath))
                    {
                        //driverDirectories.Add(Path.GetDirectoryName(filePath));
                        driverDirectories.Add(filePath);
                    }
                }

                foreach (string directory in Directory.GetDirectories(path))
                {
                    driverDirectories.UnionWith(GetAllDriverDirectories(directory)); // 具有去重效果
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("无权访问目录：" + path);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("路径过长：" + path);
            }

            return new List<string>(driverDirectories);
        }

        // 判断是否为驱动文件，此处需要根据真实情况来判断
        public bool IsDriverFile(string filePath)
        {
            // 此处以文件扩展名为“.sys”，“.dll”和“.inf”为例，实际情况需要根据具体需求判断
            string extension = Path.GetExtension(filePath).ToLower();
            //extension == ".sys" || extension == ".cat" || 
            return extension == ".inf";
        }

        public List<string> GetUniqueFiles(string dirA, string dirB)
        {
            var filesA = Directory.GetFiles(dirA, "*", SearchOption.AllDirectories)
                      .Select(f => f.Substring(dirA.Length))
                      .ToList();

            var filesB = Directory.GetFiles(dirB, "*", SearchOption.AllDirectories)
                .Select(f => f.Substring(dirB.Length))
                .ToList();

            return filesA.Except(filesB).Select(x => dirA + x).ToList();
        }

        //public List<string> GetUniqueFiles(string dirA, string dirB)
        //{
        //    var filesA = Directory.GetFiles(dirA, "*", SearchOption.AllDirectories)
        //        .ToDictionary(f => f.Substring(dirA.Length), f => GetChecksum(f));

        //    var filesB = Directory.GetFiles(dirB, "*", SearchOption.AllDirectories)
        //        .ToDictionary(f => f.Substring(dirB.Length), f => GetChecksum(f));

        //    return filesA.Except(filesB).Select(x => Path.Combine(dirA, x.Key)).ToList();
        //}

        //public byte[] GetChecksum(string file)
        //{
        //    using (var stream = new BufferedStream(File.OpenRead(file), 1200000))
        //    using (var sha = SHA256.Create())
        //    {
        //        return sha.ComputeHash(stream);
        //    }
        //}
    }
}
