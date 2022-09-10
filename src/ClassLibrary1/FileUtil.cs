using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ClassLibrary1
{
    public static class FileUtil
    {
        public static string GetFileMD5(string fileName)
        {
            try
            {
                var file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                var md5 = new MD5CryptoServiceProvider();
                var retVal = md5.ComputeHash(file);
                file.Close();
                var sb = new StringBuilder();
                for (var i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName,
          bool copySubDirs, bool isOverWrite, Action<string> action)
        {
            var dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists) return;
            var dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            foreach (var file in dir.GetFiles())
            {
                var temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, isOverWrite);
                if (action != null) action.Invoke(file.Name);
            }
            if (copySubDirs)
            {
                foreach (var subdir in dirs)
                {
                    var temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, true, isOverWrite, action);
                }
            }
            Directory.Delete(sourceDirName, true);
        }

        public static string GetTempDirectory(string name)
        {
            var path2 = $"generalupdate_{DateTime.Now.ToString("yyyy-MM-dd")}_{name}";
            var tempDir = Path.Combine(Path.GetTempPath(), path2);
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            return tempDir;
        }


        public static FileInfo[] GetAllFiles(string path)
        {
            try
            {
                var files = new List<FileInfo>();
                files.AddRange(new DirectoryInfo(path).GetFiles());
                var tmpdics = new DirectoryInfo(path).GetDirectories();
                foreach (var dic in tmpdics)
                {
                    files.AddRange(GetAllFiles(dic.FullName));
                }
                return files.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetJsonFile(string filepath, Encoding encoding)
        {
            string json = string.Empty;
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, encoding))
                {
                    json = sr.ReadToEnd().ToString();
                }
            }
            return json;
        }
    }
}
