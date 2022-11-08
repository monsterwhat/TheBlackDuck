using SyncBlackDuck.ViewModel.cAdminViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncBlackDuck.Views.AdminViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminGestUsuarios : ContentPage
    {
        public AdminGestUsuarios()
        {
            InitializeComponent();
            BindingContext = new AdminUserGestViewModel();
        }

        private void ContentView_BindingContextChanged(object sender, EventArgs e)
        {

        }
    }
}