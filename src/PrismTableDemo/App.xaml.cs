using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using PrismTableDemo.Views;

namespace PrismTableDemo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        
    }


    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        // 配置模块
    }
}