using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyGCWPF.Models;

namespace MyGCWPF.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        ObservableCollection<MyImage2> _myImages;
        public ICommand ClearCommand { get; }

        public ObservableCollection<MyImage2> MyImages 
        { 
            get => _myImages ?? (_myImages = new ObservableCollection<MyImage2>());
            set => SetProperty(ref _myImages, value);
        }


        internal MainViewModel() 
        {
            ClearCommand = new RelayCommand(ClearCallback);

            for (int i = 0; i < 300; i++)
            {
                MyImages.Add(new MyImage2(3 * 1024 * 1024) { MyPath = "/Images/1.jpg" });
            }
        }

        private void ClearCallback()
        {
            foreach (var item in MyImages)
            {
                item.Dispose();
            }
            MyImages.Clear();
        }
    }
}
