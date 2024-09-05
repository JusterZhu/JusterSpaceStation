using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrismTableDemo.Views;

namespace PrismTableDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IRegionManager _regionManager;
    //private ObservableCollection<MyItem> _myItems = new ObservableCollection<MyItem>();

    /*public ObservableCollection<MyItem> MyItems
    {
        get => _myItems;
        set => _myItems = value;
    }*/

    public MainWindow(IRegionManager regionManager)
    {
        InitializeComponent();
        _regionManager = regionManager;
        _regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewA));
        _regionManager.RegisterViewWithRegion("TabRegion", typeof(ViewB));
        /*MyItems.Add(new MyItem() { Name = nameof(ViewA), RegionName = "TabRegion" });
        MyItems.Add(new MyItem() { Name = nameof(ViewB), RegionName = "TabRegion" });*/
        DataContext = this;
    }
}

public class MyItem
{
    public string Name { get; set; }
    public string RegionName { get; set; }
}