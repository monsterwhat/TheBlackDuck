using Sync_test;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Views.SuperAdminViews;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cSuperAdminViewModel
{
    internal class SAdminViewModel : INotifyPropertyChanged
    {
        private string user_telefono;
        private user loggedInUser;
        public SAdminViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public int User_Telefono { get => User_Telefono; set => User_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

        // ICommands para las redirecciones de paginas
        public ICommand GestionAdministradores => GestionAdminPage();
        public ICommand CSCerrarSesion => CerrarSesion();
        public ICommand BackAdminMain => BackAdminMainP();

        // Metodos Command para hacer los metodos async
        private Command GestionAdminPage()
        {
            return new Command(async () => await GestionAdminPageAsync());
        }
        private Command CerrarSesion()
        {
            return new Command(async () => await CerrarSesionAsync());
        }
        private Command BackAdminMainP()
        {
            return new Command(async () => await BackAdminAsync());
        }
        private Task GestionAdminPageAsync()
        {
            try
            {
                // Redireccion usuarios
                Application.Current.MainPage = new NavigationPage(new SuperAdminGestAdmin());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cerrar sesion");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        private Task CerrarSesionAsync()
        {
            try
            {
                // Aqui hay que cerrar la sesion guardada
                Application.Current.Properties["id"] = 0;
                Application.Current.MainPage = new NavigationPage(new MainPage());
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

    }
}

