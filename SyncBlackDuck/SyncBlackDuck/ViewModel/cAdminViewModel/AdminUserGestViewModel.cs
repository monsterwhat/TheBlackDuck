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
    public partial class AdminUserGestViewModel : AdminBaseVM, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<user> listaUsuarios = new List<user>();
        private userImpl userController = new userImpl();


        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

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
                RaisePropertyChanged("userCollection");
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
                RaisePropertyChanged("SelectedItems");
            }
        }

        public AdminUserGestViewModel(INavigation navigation, SfDataGrid datagrid)
        {
            //UsuariosInfo es la lista de usuarios
            Navigation = navigation;
            usuariosInfo = new ObservableCollection<user>();
            //SectedItem es el Usuario.
            selectedItem = new Object();
            //Cargamos la lista de clientes;
            CargarClientes();

            DatagridControlls grid = new DatagridControlls();
            datagrid.CurrentCellEndEdit += grid.DataGrid_CurrentCellEndEdit;
        }


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
        }


        // ICommands para las redirecciones de paginas
        public ICommand BackAdminMain => BackAdminMainP();

        // Metodos Command para hacer los metodos async
        private Command BackAdminMainP()
        {
            return new Command(async () => await BackAdminAsync());
        }
        /// <summary>
        /// Metodo para cargar los clientes en el observable collection
        /// </summary>
        private void CargarClientes()
        {
            try
            {
                //Cargamos la lista
                listaUsuarios = userController.verClientes();
                //Iteramos para insertar en el observable collection
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
        private Task BackAdminAsync()
        {
            try
            {
                Application.Current.MainPage = new NavigationPage(new AdminMainPage());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cambiar de pagina");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

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

        public void EndEditCell(object sender, GridCurrentCellEndEditEventArgs args)
        {
            Console.WriteLine("CurrentCellEndEdit");
            Console.WriteLine("Row index: " + args.RowColumnIndex);
            Console.WriteLine("Column: " + args.OldValue);
            Console.WriteLine("Column: " + args.NewValue);

        }

    }
}