using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using SyncBlackDuck.Views.AdminViews;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminUserGestVM : AdminBaseVM
    {
        private List<user> listaUsuarios = new List<user>();
        private userImpl userController = new userImpl();
        public int SelectedIndex;
        public SfDataGrid userGrid;
        public int row;
        public string Dato;
        public int UserID;
        public AdminUserGestVM(INavigation navigation, SfDataGrid datagrid)
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

        private Command agregarUsuario;
        public ICommand AgregarUsuario => agregarUsuario ??= new Command(PerformAgregarUsuario);

        private void PerformAgregarUsuario()
        {

        }

        private Command borrarUsuario;
        public ICommand BorrarUsuario => borrarUsuario ??= new Command(PerformBorrarUsuario);

        private void PerformBorrarUsuario()
        {

        }

        private Command salvar;
        public ICommand Salvar => salvar ??= new Command(PerformSalvar);

        private void PerformSalvar()
        {

        }


        // ICommands para las redirecciones de paginas
        public ICommand BackAdminMain => BackAdminMainP();

        // Metodos Command para hacer los metodos async
        private Command BackAdminMainP()
        {
            return new Command(async () => await BackAdminAsync());
        }

        private Task BackAdminAsync()
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

        #endregion commands

        private void CargarClientes()
        {
            try
            {
                listaUsuarios = userController.verClientes();
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