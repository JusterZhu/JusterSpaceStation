using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiVideoDemo.ViewModels
{
    internal class MainViewModel
    {
        private string _url;

        public string Url { get => _url; set => _url = value; }

        public MainViewModel() 
        {
#if WINDOWS
            Url = @"C:\Users\zhuzh\Downloads\testvideo.mp4";
#endif

#if ANDROID 
            Url = @"embed://testvideo.mp4";
#endif
        }
    }
}
