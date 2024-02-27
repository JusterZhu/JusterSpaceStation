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
            Url = "https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
        }
    }
}
