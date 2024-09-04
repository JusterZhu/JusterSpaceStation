using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // 创建一个新的进程启动信息对象
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "App/procdump64.exe"; // 替换为你想启动的控制台应用程序的路径
        startInfo.Arguments = "-e -ma 5892"; // 如果需要，可以在这里添加命令行参数
        startInfo.RedirectStandardOutput = true; // 重定向标准输出
        startInfo.RedirectStandardError = true; // 重定向标准错误输出
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true; // 如果不想显示窗口，可以设置为 true

        // 创建一个新的进程对象
        Process process = new Process();
        process.StartInfo = startInfo;
        process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
        process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);

        try
        {
            // 启动进程
            process.Start();

            // 开始异步读取输出
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            // 等待进程退出
            await process.WaitForExitAsync();

            while (true)
            {
            }
        }
        catch (Exception ex)
        {
            // 捕获并处理异常
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
        // 输出捕获的内容
        if (!string.IsNullOrEmpty(outLine.Data))
        {
            Console.WriteLine(outLine.Data);
        }
    }
}