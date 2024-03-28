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

namespace TreeViewRightExpanderDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Node> FirstLevelNodes { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            FirstLevelNodes = new ObservableCollection<Node>
    {
        new Node { NodeName = "Node1", SecondLevelNodes = new ObservableCollection<Node>
            {
                new Node { NodeName = "Child1" },
                new Node { NodeName = "Child2" }
            }
        },
        new Node { NodeName = "Node2", SecondLevelNodes = new ObservableCollection<Node>
            {
                new Node { NodeName = "Child3" },
                new Node { NodeName = "Child4" }
            }
        }
    };

            DataContext = this;
        }

        public class Node
        {
            public string NodeName { get; set; }
            public ObservableCollection<Node> SecondLevelNodes { get; set; }
        }

        public class ViewModel
        {
            public ObservableCollection<Node> FirstLevelNodes { get; set; }
        }
    }
}