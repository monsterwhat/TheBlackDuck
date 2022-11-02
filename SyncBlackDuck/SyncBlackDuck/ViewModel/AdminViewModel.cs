using Sync_test;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using SyncBlackDuck.Views.AdminViews;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private userImpl userController;
        private List<user> listaUsuarios = new List<user>();
        private user usuarioSeleccionado;

        public event PropertyChangedEventHandler PropertyChanged;

        public AdminViewModel(userImpl userController)
        {
            this.userController = userController;
        }


        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public int User_Telefono { get => User_Telefono; set => User_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }
        public AdminViewModel()
        {
            GenerarUsuarios();
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
                if (userController.verTodo() != null)
                {
                listaUsuarios = userController.verTodo();
                }
                else
                {
                    Console.WriteLine("Error lista usuarios");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public List<user> ListaUsuarios { get { return listaUsuarios; } set { listaUsuarios = value; OnPropertyChanged(nameof(ListaUsuarios)); } }

        public user UsuarioSeleccionado { get { return usuarioSeleccionado; } set { usuarioSeleccionado = value; OnPropertyChanged(nameof(usuarioSeleccionado)); } }


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
