using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using SyncBlackDuck.Views.AdminViews;
using SyncBlackDuck.Views.SuperAdminViews;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cSuperAdminViewModel
{
    public partial class SAdminGestAdmin : SAdminBaseVM, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private user usuarioSeleccionado;
        private List<user> listaUsuarios = new List<user>();
        private userImpl userController = new userImpl();

        public List<user> ListaUsuarios { get { return listaUsuarios; } set { listaUsuarios = value; OnPropertyChanged(nameof(ListaUsuarios)); } }
        public user UsuarioSeleccionado { get { return usuarioSeleccionado; } set { usuarioSeleccionado = value; OnPropertyChanged(nameof(usuarioSeleccionado)); } }
        public SAdminGestAdmin(INavigation navigation, SfDataGrid datagrid)
        {
            Navigation = navigation;
            listaUsuarios = CargarAdministradores();
        }

        // ICommands para las redirecciones de paginas
        public ICommand BackSAdminMain => BackSAdminMainP();

        // Metodos Command para hacer los metodos async
        private Command BackSAdminMainP()
        {
            return new Command(async () => await BackSAdminAsync());
        }

        private List<user> CargarAdministradores()
        {
            try
            {
                return userController.verAdministradores();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        private Task BackSAdminAsync()
        {
            try
            {
                Application.Current.MainPage = new NavigationPage(new SuperAdminMainPage());
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

        private Command modificarUsuario;
        public ICommand ModificarUsuario => modificarUsuario ??= new Command(PerformModificarUsuario);

        private void PerformModificarUsuario()
        {
        }

        private Command borrarUsuario;
        public ICommand BorrarUsuario => borrarUsuario ??= new Command(PerformBorrarUsuario);

        private void PerformBorrarUsuario()
        {
        }
   
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
    }
}