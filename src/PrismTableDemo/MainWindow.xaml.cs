using System.Windows;
using PrismTableDemo.Views;

namespace PrismTableDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IRegionManager _regionManager;
    
    public MainWindow(IRegionManager regionManager)
    {
        InitializeComponent();
        _regionManager = regionManager;
        _regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewA));
        _regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewB));
        DataContext = this;
    }

    private void BtnRemove_OnClick(object sender, RoutedEventArgs e)
    {
        var region = _regionManager.Regions["TabRegion"];
        var view = region.Views.FirstOrDefault(v => v.GetType() == typeof(ViewA));
        if (view != null)
        {
            region.Remove(view);
        }
    }

    private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
    {
        _regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewA));
    }

    private void BtnShowViewC_OnClick(object sender, RoutedEventArgs e)
    {
        _regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewC));
    }
}