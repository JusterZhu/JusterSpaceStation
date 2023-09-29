using ClassLibrary1.MyTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class FileProvider
    {
        private long _fileCount = 0;

        public void Compare(string leftPath, string rightPath,ref List<FileNode> fileNodes)
        {
            var leftFilenodes = ReadAsync(leftPath);
            var rightFilenodes = ReadAsync(rightPath);
            var tree = new FileTree(leftFilenodes);
            var tree0 = new FileTree(rightFilenodes);
            tree.Compare(tree.GetRoot(), tree0.GetRoot(), ref fileNodes);
            foreach (var item in fileNodes)
            {
                Console.WriteLine($"{item.Name} - { item.Id } - { item.MD5 }");
            }
        }

        private IEnumerable<FileNode> ReadAsync(string path)
        {
            var resultFiles = new List<FileNode>();

            //foreach (var subPath in Directory.GetFiles(path))
            //{
            //    var md5 = FileUtil.GetFileMD5(subPath);
            //    var subFileInfo = new FileInfo(subPath);
            //    resultFiles.Add(new FileNode() { Id = GetId(), Path = path, Name = subFileInfo.Name, MD5 = md5 });
            //}

            //foreach (var subPath in Directory.GetDirectories(path))
            //{
            //    resultFiles.AddRange(ReadAsync(subPath));
            //}


            Parallel.ForEach(Directory.GetFiles(path), (subPath) =>
            {
                var md5 = FileUtil.GetFileMD5(subPath);
                var subFileInfo = new FileInfo(subPath);
                //resultFiles.Add(new FileNode() { Id = GetId(), Path = path, Name = subFileInfo.Name, MD5 = md5 });
            });
            Parallel.ForEach(Directory.GetDirectories(path), (subPath) =>
            {
                resultFiles.AddRange(ReadAsync(subPath));
            });
            ResetId();
            return resultFiles;
        }

        private IEnumerable<FileNode> GetSub(string sub) 
        {
            yield return new FileNode() {  };
        }

        private long GetId()=> Interlocked.Increment(ref _fileCount);

        private void ResetId()=> Interlocked.Exchange(ref _fileCount, 0);
    }
}
