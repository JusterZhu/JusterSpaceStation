using CrashReporterDotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyCrashReporter
{
    internal class Program
    {
        //https://github.com/ravibpatel/CrashReporter.NET
        private static ReportCrash _reportCrash;

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args1) =>
            {
                SendReport((Exception)args1.ExceptionObject);
            };

            _reportCrash = new ReportCrash("Email where you want to receive crash reports")
            {
                Silent = true,
                ShowScreenshotTab = true,
                IncludeScreenshot = false,
                #region Optional Configuration
                WebProxy = new WebProxy("Web proxy address, if needed"),
                AnalyzeWithDoctorDump = true,
                DoctorDumpSettings = new DoctorDumpSettings
                {
                    ApplicationID = new Guid("Application ID you received from DrDump.com"),
                    OpenReportInBrowser = true
                }
                #endregion
            };
            _reportCrash.RetryFailedReports();
        }

        public static void SendReport(Exception exception, string developerMessage = "")
        {
            _reportCrash.DeveloperMessage = developerMessage;
            _reportCrash.Silent = false;
            _reportCrash.Send(exception);
        }

        public static void SendReportSilently(Exception exception, string developerMessage = "")
        {
            _reportCrash.DeveloperMessage = developerMessage;
            _reportCrash.Silent = true;
            _reportCrash.Send(exception);
        }
    }
}
