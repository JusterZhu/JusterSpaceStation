namespace BackupDemo
{
    internal class Program
    {
        private static string appPath  = @"D:\backup_test\app";
        private static string backupPath = @"D:\backup_test\backup";
        private static string packetPath = @"D:\backup_test\packet";

        static void Main(string[] args)
        {
            FileBackup.CopyFiles(packetPath,appPath,backupPath);
            Console.Read();
        }
    }
}
