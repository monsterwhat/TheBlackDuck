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
using Windows.System;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminPagosGestVM : AdminBaseVM
    {
        private List<pagos> listaPagos = new List<pagos>();
        private pagosImpl pagosController = new pagosImpl();
        public int row;
        public string Dato;
        public int PagoID;

        public AdminPagosGestVM(INavigation navigation, SfDataGrid datagrid)
        {
            Navigation = navigation;
            pagosInfo = new ObservableCollection<pagos>();
            selectedItem = new Object();
            CargarPagos();
            datagrid.CurrentCellBeginEdit += DataGrid_CurrentCellBeginEdit;
            datagrid.CurrentCellEndEdit += DataGrid_CurrentCellEndEdit;
        }

        #region CellListeners

        public void DataGrid_CurrentCellBeginEdit(object sender, GridCurrentCellBeginEditEventArgs args)
        {
            row = args.RowColumnIndex.RowIndex;
            Dato = args.Column.MappingName;
            PagoID = pagosInfo.ElementAt(row - 1).Pagos_id;
        }

        public void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs args)
        {
            bool Estado = false;
            if (args.OldValue != args.NewValue)
            {
                pagos PagoSelecionado = pagosInfo.ElementAt(row - 1);
                Estado = pagosController.modificar(PagoSelecionado);
            }

        }

        #endregion CellListeners

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