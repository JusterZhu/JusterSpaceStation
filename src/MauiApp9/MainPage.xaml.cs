namespace MauiApp9
{
    public partial class MainPage : ContentPage
    {
        private NewWindow1 window = new NewWindow1();

        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void ShowWindowBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current?.ActivateWindow(window);
            Application.Current.
        }
    }
}
