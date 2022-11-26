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
            BindingContext = new LoginVM(Navigation);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BindingContext = null;
            GC.Collect();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new LoginVM(Navigation);
            GC.Collect();
        }
    }
}
