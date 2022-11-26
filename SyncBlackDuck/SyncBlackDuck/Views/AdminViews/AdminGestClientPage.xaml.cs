using SyncBlackDuck.ViewModel.cAdminViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            GC.Collect();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}