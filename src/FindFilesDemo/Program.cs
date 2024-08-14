namespace FindFilesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"D:\test\a";
            string targetDirectory = @"D:\test\b";
            string resultDir = @"D:\test\result";

            CopyMatchingFiles(sourceDirectory, targetDirectory, resultDir);
            Console.Read();
        }

        public static void CopyMatchingFiles(string appPath, string patchPath, string destinationPath)
        {
            foreach (string filePath in Directory.GetFiles(patchPath, "*.*", SearchOption.AllDirectories))
            {
                string correspondingPathInA = filePath.Replace(patchPath, appPath);

                if (File.Exists(correspondingPathInA))
                {
                    string correspondingPathInC = filePath.Replace(patchPath, destinationPath);

                    string directoryName = Path.GetDirectoryName(correspondingPathInC);
                    if (!Directory.Exists(directoryName))
                    {
                        Directory.CreateDirectory(directoryName);
                    }
                    File.Copy(correspondingPathInA, correspondingPathInC, true);
                }
            }
        }
    }
}
