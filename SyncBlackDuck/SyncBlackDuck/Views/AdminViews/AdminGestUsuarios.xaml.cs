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

        public class DatagridControlls
        {
            public DatagridControlls()
            {

            }

            public void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs args)
            {
                Console.WriteLine("CurrentCellEndEdit");
                Console.WriteLine("Row index: " + args.RowColumnIndex);
                Console.WriteLine("Column: " + args.OldValue);
                Console.WriteLine("Column: " + args.NewValue);
            }
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BindingContext = null;
            GC.Collect();
        }
    }
}