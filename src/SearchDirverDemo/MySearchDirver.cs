using System;
using System.Collections.Generic;
using System.Linq;
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
                        driverDirectories.Add(Path.GetDirectoryName(filePath));
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
            return extension == ".sys" || extension == ".cat" || extension == ".inf";
        }
    }
}
