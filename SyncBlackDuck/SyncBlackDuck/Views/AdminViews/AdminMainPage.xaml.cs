using System;
using SyncBlackDuck.ViewModel.cAdminViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncBlackDuck.Views.AdminViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminMainPage : ContentPage
    {
        public AdminMainPage()
        {
            InitializeComponent();
            BindingContext = new AdminVM(Navigation);
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