using SyncBlackDuck.ViewModel;
using SyncBlackDuck.ViewModel.cAdminViewModel;
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
            GC.Collect();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
