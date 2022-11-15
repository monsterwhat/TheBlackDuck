using SyncBlackDuck.Services.Implementaciones;
using SyncBlackDuck.ViewModel.cAdminViewModel;
using Syncfusion.SfDataGrid.XForms;
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
            BindingContext = new AdminUserGestViewModel(Navigation,this.dataGrid);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BindingContext = null;
            GC.Collect();
        }
    }
}