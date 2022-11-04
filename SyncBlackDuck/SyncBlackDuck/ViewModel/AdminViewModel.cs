using Sync_test;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using SyncBlackDuck.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{
    internal class AdminViewModel : userImpl, INotifyPropertyChanged
    {
        private string user_telefono;
        private user loggedInUser;
        private userImpl userController = new userImpl();
        private user usuarioSeleccionado;
        public List<user> listaUsuarios = new List<user>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public int User_Telefono { get => User_Telefono; set => User_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }
        public List<user> ListaUsuarios { get { return listaUsuarios; } set { listaUsuarios = value; OnPropertyChanged(nameof(ListaUsuarios)); } }
        public user UsuarioSeleccionado { get { return usuarioSeleccionado; } set { usuarioSeleccionado = value; OnPropertyChanged(nameof(usuarioSeleccionado)); } }

        public AdminViewModel()
        {

        }

        // ICommands para las redirecciones de paginas
        public ICommand GestionUsuarios => GestionUserPage();
        public ICommand CerrarSesion => CerrarSesionAdmin();
        public ICommand BackAdminMain => BackAdminMainP();

        // Metodos Command para hacer los metodos async
        private Command GestionUserPage()
        {
            return new Command(async () => await GestionUserAsync());
        }
        private Command CerrarSesionAdmin()
        {
            return new Command(async () => await CSAdminAsync());
        }
        private Command BackAdminMainP()
        {
            return new Command(async () => await BackAdminAsync());
        }
        private Task GestionUserAsync()
        {
            try
            {
                // Redireccion usuarios
                App.Current.MainPage = new NavigationPage(new AdminGestUsuarios());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cerrar sesion");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        private Task CSAdminAsync()
        {
            try
            {
                // Aqui hay que cerrar la sesion guardada
                Application.Current.Properties["id"] = 0;
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cerrar sesion");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
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
        private void GenerarUsuarios()
        {
            try
            {
                /*
                listaUsuarios = new List<user>();

                for (int i = 0; i < 20; i++)
                {
                    user user = new user() { User_id = 1, User_name = "Al", User_password = "1234", User_rol = "admin", User_telefono = 99999999, User_time = DateTime.Now };
                    listaUsuarios.Add(user);
                }
                //listaUsuarios = new List<user>(userController.verTodo());
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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
