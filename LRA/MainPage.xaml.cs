using Xamarin.Essentials;
using Xamarin.Forms;

namespace LRA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            wvMain.Navigating += WvMain_Navigating;
        }

        private void WvMain_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.StartsWith("mailto") || e.Url.StartsWith("tel"))
            {
                _ = Launcher.OpenAsync(e.Url);

                e.Cancel = true;
            }
        }
    }
}