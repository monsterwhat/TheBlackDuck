using System;
using TheBlackDuck.Services;
using TheBlackDuck.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheBlackDuck
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
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
