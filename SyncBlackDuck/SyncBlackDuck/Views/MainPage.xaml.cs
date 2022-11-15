using SyncBlackDuck.Services;
using SyncBlackDuck.ViewModel;
using System;
using Xamarin.Forms;

namespace SyncBlackDuck.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BindingContext = null;
            GC.Collect();
        }
    }
}
