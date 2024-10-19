using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.ViewModels
{
    public partial class Form1ViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        public Form1ViewModel() 
        {
             Name = "test";
        }

        [RelayCommand()]
        public void MySetCommand() 
        {
            MessageBox.Show(Name);
        }
    }
}
