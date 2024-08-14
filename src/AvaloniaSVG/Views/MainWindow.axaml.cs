using Avalonia.Controls;
using AvaloniaSVG.ViewModels;

namespace AvaloniaSVG.Views
{
    public partial class MainWindow : Window
    {
        private Avalonia.Controls.Shapes.Path Path { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}