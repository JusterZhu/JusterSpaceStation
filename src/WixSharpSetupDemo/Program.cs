using System;
using System.Windows.Forms;
using WixSharp;
using WixSharp.UI.WPF;

namespace WixSharpSetupDemo
{
    internal class Program
    {
        static void Main()
        {
            var project = new ManagedProject("MyProduct",
                              new Dir(@"%ProgramFiles%\My Company\My Product",
                                  new File("Program.cs")));

            project.GUID = new Guid("6fe30b47-2577-43ad-9095-1861ba25889b");

            // project.ManagedUI = ManagedUI.DefaultWpf; // all stock UI dialogs

            //custom set of UI WPF dialogs
            project.ManagedUI = new ManagedUI();

            project.ManagedUI.InstallDialogs.Add<WixSharpSetupDemo.WelcomeDialog>()
                                            .Add<WixSharpSetupDemo.LicenceDialog>()
                                            .Add<WixSharpSetupDemo.FeaturesDialog>()
                                            .Add<WixSharpSetupDemo.InstallDirDialog>()
                                            .Add<WixSharpSetupDemo.ProgressDialog>()
                                            .Add<WixSharpSetupDemo.ExitDialog>();

            project.ManagedUI.ModifyDialogs.Add<WixSharpSetupDemo.MaintenanceTypeDialog>()
                                           .Add<WixSharpSetupDemo.FeaturesDialog>()
                                           .Add<WixSharpSetupDemo.ProgressDialog>()
                                           .Add<WixSharpSetupDemo.ExitDialog>();

            //project.SourceBaseDir = "<input dir path>";
            //project.OutDir = "<output dir path>";

            project.BuildMsi();
        }
    }
}