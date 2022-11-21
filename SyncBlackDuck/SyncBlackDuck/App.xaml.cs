using SyncBlackDuck;
using SyncBlackDuck.Services;
using SyncBlackDuck.Views;
using SyncBlackDuck.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncBlackDuck
{
    public partial class App : Application
    {
        public App()
        {
            // Licencia de Syncfusion
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzY1MjQ0QDMyMzAyZTMzMmUzMEc1dUZwWlRRSnlXMVhZdnNUNGR5U0R3TlZSaUhTRzhpcUVPN3hyQmZoYjg9");


            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
