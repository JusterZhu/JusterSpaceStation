using WinFormsApp.ViewModels;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object? sender, EventArgs e)
        {
            form1ViewModelBindingSource.DataSource = new Form1ViewModel();
        }
    }
}
