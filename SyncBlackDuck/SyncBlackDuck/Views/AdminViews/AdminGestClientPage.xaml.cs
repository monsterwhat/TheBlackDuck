using SyncBlackDuck.ViewModel.cAdminViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncBlackDuck.Views.AdminViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminGestClientPage : ContentPage
	{
		public AdminGestClientPage ()
		{
			InitializeComponent ();
            BindingContext = new AdminUserGestVM(Navigation, this.dataGrid);
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
            BindingContext = new AdminUserGestVM(Navigation, this.dataGrid);
            GC.Collect();
        }
    }
}