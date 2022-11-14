using SyncBlackDuck.ViewModel;
using SyncBlackDuck.ViewModel.cAdminViewModel;
using Syncfusion.SfDataGrid.XForms;
using System;
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
            BindingContext = new AdminViewModel(Navigation);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BindingContext = null;
            GC.Collect();
        }
    }
}