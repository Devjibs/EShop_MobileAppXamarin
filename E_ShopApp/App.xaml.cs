using E_ShopApp.Pages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_ShopApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var accesstoken = Preferences.Get("accessToken", string.Empty);
            if (string.IsNullOrEmpty(accesstoken))
            {
                MainPage = new NavigationPage(new SignUpPage());
            }
            else
            {
                MainPage = new NavigationPage(new HomePage());
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
