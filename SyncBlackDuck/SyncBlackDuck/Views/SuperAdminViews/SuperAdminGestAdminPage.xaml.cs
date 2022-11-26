using SyncBlackDuck.ViewModel.cSuperAdminViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncBlackDuck.Views.SuperAdminViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuperAdminGestAdmin : ContentPage
    {

        public SuperAdminGestAdmin()
        {
            InitializeComponent();
            BindingContext = new SAdminGestAdminVM(Navigation, this.dataGrid);
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