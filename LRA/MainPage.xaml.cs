using System;

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

        private async void WvMain_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.StartsWith("mailto") || e.Url.StartsWith("tel"))
            {
                _ = Launcher.OpenAsync(e.Url);

                e.Cancel = true;
            }

            if (e.Url.StartsWith("geo"))
            {
                string[] splitArr = e.Url.Replace("geo:", "").Split(',');

                await Map.OpenAsync(new Location(Convert.ToDouble(splitArr[0]), Convert.ToDouble(splitArr[1])));

                e.Cancel = true;
            }

            if (e.Url.StartsWith("https://www.facebook.com"))
            {
                await Xamarin.Essentials.Launcher.OpenAsync("fb://page/880109982002154");

                e.Cancel = true;
            }
        }
    }
}