using System.Drawing.Imaging;
using TaskTamer.ViewModels;
//using TaskTamer.WinForms.Views;

using static DemoToolkit.Mvvm.WinForms.Services.IWinFormsStartService;

namespace TaskTamer.WinForms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

#pragma warning disable WFO5001
        Application.SetColorMode(SystemColorMode.System);
#pragma warning restore WFO5001

        //Application.SetDefaultVisualStylesMode(VisualStylesMode.Latest);

        // We're registering the ViewModels and the view here:
        //RegisterView<ProjectViewModel>(() => new FrmManageProjects());
        RegisterView<MainViewModel>(() => new FrmTaskTamerMain());

        // We're setting the start ViewModel here:
        SetStartViewModel<MainViewModel>();

        // Let's go!
        Run();
    }
}
