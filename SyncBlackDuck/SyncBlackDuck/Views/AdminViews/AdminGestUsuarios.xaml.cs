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
            BindingContext = new AdminUserGestViewModel();
            DatagridControlls grid = new DatagridControlls();
            this.dataGrid.CurrentCellEndEdit += grid.DataGrid_CurrentCellEndEdit;
            this.dataGrid.CurrentCellBeginEdit += grid.DataGrid_CurrentCellBeginEdit;

        }

        public class DatagridControlls
        {
            public DatagridControlls()
            {

            }

            public void DataGrid_CurrentCellBeginEdit(object sender, GridCurrentCellBeginEditEventArgs args)
            {
                /*
                Console.WriteLine("CurrentCellBeginEdit");
                Console.WriteLine("Row index: " + args.RowColumnIndex);
                Console.WriteLine("Column: " + args.Column);
                */
            }

            public void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs args)
            {
                Console.WriteLine("CurrentCellEndEdit");
                Console.WriteLine("Row index: " + args.RowColumnIndex);
                Console.WriteLine("Column: " + args.OldValue);
                Console.WriteLine("Column: " + args.NewValue);

                //userImpl userController = new userImpl();
                //userController.
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