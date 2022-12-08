using SyncBlackDuck.ViewModel.cAdminViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncBlackDuck.Views.AdminViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminGestPagosPage : ContentPage
	{
		public AdminGestPagosPage (int swipedUserID)
		{
			InitializeComponent ();
            BindingContext = new AdminPagosGestVM(Navigation, this.dataGrid, swipedUserID);
            
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            GC.Collect();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BackAdmin.IsEnabled = true;
        }
    }
}