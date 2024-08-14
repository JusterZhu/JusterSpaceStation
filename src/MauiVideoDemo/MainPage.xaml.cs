using CommunityToolkit.Maui.Views;
using MauiVideoDemo.ViewModels;

namespace MauiVideoDemo
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
            Loaded += MainPage_Loaded;
            Unloaded += OnUnloaded;
        }

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            mediaElement.Source = new Uri(@"...\\testvideo.mp4");
        }

        private void OnUnloaded(object? sender, EventArgs e)
        {
            mediaElement.Handler?.DisconnectHandler();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            mediaElement.Play();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            mediaElement.Stop();
        }

        private void BtnFull_Clicked(object sender, EventArgs e)
        {
            
#if WINDOWS
            mediaElement.WidthRequest = Width;
            mediaElement.HeightRequest = Height;
#endif

#if ANDROID
            StkControl.IsVisible = false;
            mediaElement.IsVisible = false;
            mediaElement.Pause();
            mediaElement.IsVisible = true;
            mediaElement.HeightRequest = 300;
            mediaElement.WidthRequest = 850;
#endif
        }
    }
}
