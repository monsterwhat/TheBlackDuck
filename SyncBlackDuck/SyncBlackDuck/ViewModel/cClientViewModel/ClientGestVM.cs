using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using SyncBlackDuck.Views.AdminViews;
using SyncBlackDuck.Views.ClientViews;
using Syncfusion.Data.Extensions;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cClientViewModel
{
 public partial class ClientGestVM : ClienteBaseVM
    {
        private user usuarioSeleccionado = new user();
        private List<user> listaUsuarios = new List<user>();
        private userImpl userController = new userImpl();
        public int row;
        public string Dato;
        public int UserID;

        public ClientGestVM(INavigation navigation, SfDataGrid datagrid)
        {
            Navigation = navigation;
            usuariosInfo = new ObservableCollection<user>();
            selectedItem = new Object();
            CargarClientes();
            datagrid.CurrentCellBeginEdit += DataGrid_CurrentCellBeginEdit;
            datagrid.CurrentCellEndEdit += DataGrid_CurrentCellEndEdit;
        }

        #region CellListeners

        public void DataGrid_CurrentCellBeginEdit(object sender, GridCurrentCellBeginEditEventArgs args)
        {
            row = args.RowColumnIndex.RowIndex;
            Dato = args.Column.MappingName;
            UserID = usuariosInfo.ElementAt(row - 1).User_id;
        }

        public void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs args)
        {
            bool Estado = false;
            if (args.OldValue != args.NewValue)
            {
                user UsuarioSelecionado = usuariosInfo.ElementAt(row - 1);
                Estado = userController.modificar(UsuarioSelecionado);
            }

        }

        #endregion CellListeners


        #region Listas

        private ObservableCollection<user> usuariosInfo;
        public ObservableCollection<user> usuariosInfoCollection
        {
            get { return usuariosInfo; }
            set
            {
                if (this.usuariosInfo != value)
                {
                    Console.WriteLine(value);
                    Console.WriteLine("se modifico el OC de userCollection");
                    this.usuariosInfo = value;
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

        #endregion Listas


        #region Commands

        public ICommand BackClientMain => BackClientMainP();

        private Command BackClientMainP()
        {
            return new Command(async () => await BackClientAsync());
        }

        private Task BackClientAsync()
        {
            try
            {
                Navigation.PopAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cambiar de pagina");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        #endregion Commands
        
        private void CargarClientes()
        {
            try
            {
                var tel = Application.Current.Properties["id"] as string;
                listaUsuarios = userController.verClienteEspecifico(int.Parse(tel));
                for (int i = 0; i < listaUsuarios.Count; i++)
                {
                    usuariosInfo.Add(listaUsuarios.ElementAt(i));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
