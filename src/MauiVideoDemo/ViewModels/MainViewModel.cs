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
            //D:\github_project\JusterSpaceStation\src\MauiVideoDemo\Platforms\Android\Resources\raw\BigBuckBunny.mp4
            Url = "https://www.bilibili.com/video/BV1XJ4m1e7WF"; //"https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
        }
    }
}
