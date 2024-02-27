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
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            mediaElement.Play();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            mediaElement.Stop();
        }
    }
}
