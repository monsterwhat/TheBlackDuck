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
            GC.Collect();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void StackLayout_LayoutChanged(object sender, EventArgs e)
        {

        }
    }
}
