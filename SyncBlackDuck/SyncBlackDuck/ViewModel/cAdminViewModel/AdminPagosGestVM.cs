using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminPagosGestVM : AdminBaseVM, INotifyPropertyChanged
    {
        private List<pagos> listaPagos = new List<pagos>();
        private pagosImpl pagosController = new pagosImpl();

        public AdminPagosGestVM(INavigation navigation, SfDataGrid datagrid)
        {
            Navigation = navigation;
            pagosInfo = new ObservableCollection<pagos>();
            selectedItem = new Object();
            CargarPagos();
            DatagridControlls grid = new DatagridControlls();
            datagrid.CurrentCellBeginEdit += grid.DataGrid_CurrentCellBeginEdit;
            datagrid.CurrentCellEndEdit += grid.DataGrid_CurrentCellEndEdit;
        }

        #region Listas

        private ObservableCollection<pagos> pagosInfo;
        public ObservableCollection<pagos> PagosInfoCollection
        {
            get { return pagosInfo; }
            set
            {
                if (this.pagosInfo != value)
                {
                    Console.WriteLine(value);
                    Console.WriteLine("se modifico el OC de pagosCollection");
                    this.pagosInfo = value;
                }
            }
        }

        private Object selectedItem;
        public Object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                Console.WriteLine(value);
                if (this.selectedItem != value)
                {
                    this.selectedItem = value;
                    //Se podria salvar para aplicar cambios en la BD....
                    //Actualizar(value); //Donde value es el usuario (objeto) seleccionado.
                    //Despues de actualizar necesitamos recargar la tabla(?)
                }
            }
        }

        #endregion Lista

        #region DatagridControlls

        public class DatagridControlls
        {
            public DatagridControlls()
            {

            }

            public void DataGrid_CurrentCellBeginEdit(object sender, GridCurrentCellBeginEditEventArgs args)
            {
                Console.WriteLine("CurrentCellBeginEdit");
                Console.WriteLine("Row index: " + args.RowColumnIndex);
                Console.WriteLine("Column: " + args.Column);
            }

            public void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs args)
            {
                Console.WriteLine("CurrentCellEndEdit");
                Console.WriteLine("Row index: " + args.RowColumnIndex);
                Console.WriteLine("Column: " + args.OldValue);
                Console.WriteLine("Column: " + args.NewValue);

            }
            public void EndEditCell(object sender, GridCurrentCellEndEditEventArgs args)
            {
                Console.WriteLine("CurrentCellEndEdit");
                Console.WriteLine("Row index: " + args.RowColumnIndex);
                Console.WriteLine("Column: " + args.OldValue);
                Console.WriteLine("Column: " + args.NewValue);

            }
        }

        #endregion DatagridControlls

        private void CargarPagos()
        {
            try
            {
                listaPagos = pagosController.verPendientes();
                for (int i = 0; i < listaPagos.Count; i++)
                {
                    pagosInfo.Add(listaPagos.ElementAt(i));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}