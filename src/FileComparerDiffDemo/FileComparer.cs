using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileComparerDiffDemo
{
    public class FileComparer
    {
        private string directoryA;
        private string directoryB;

        public FileComparer(string directoryA, string directoryB)
        {
            this.directoryA = directoryA.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            this.directoryB = directoryB.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
        }

        public List<string> GetFilesInBNotInA()
        {
            var filesInDirectoryA = GetAllFiles(directoryA).Select(file => file.Substring(directoryA.Length)).ToHashSet(StringComparer.InvariantCultureIgnoreCase);
            var missingFiles = GetAllFiles(directoryB).Where(fileB => !filesInDirectoryA.Contains(fileB.Substring(directoryB.Length))).ToList();

            return missingFiles;
        }

        private IEnumerable<string> GetAllFiles(string directoryPath)
        {
            var directories = new Stack<string>();
            directories.Push(directoryPath);

            while (directories.Count > 0)
            {
                var currentDirectory = directories.Pop();

                // Excluding directory with .inf
                if (Directory.EnumerateFiles(currentDirectory, "*.inf").Any())
                    continue;

                IEnumerable<string> currentFiles;
                try
                {
                    currentFiles = Directory.EnumerateFiles(currentDirectory);
                }
                catch
                {
                    continue;
                }

                foreach (var file in currentFiles)
                    yield return file;

                IEnumerable<string> subDirectories;
                try
                {
                    subDirectories = Directory.EnumerateDirectories(currentDirectory);
                }
                catch
                {
                    continue;
                }

                foreach (var subDirectory in subDirectories)
                    directories.Push(subDirectory);
            }
        }
    }
}
