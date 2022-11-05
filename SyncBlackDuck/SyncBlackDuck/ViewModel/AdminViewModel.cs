using Sync_test;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Views.AdminViews;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{
    internal class AdminViewModel : INotifyPropertyChanged
    {
        private string user_telefono;
        private user loggedInUser;

        public AdminViewModel()
        {

        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public int User_Telefono { get => User_Telefono; set => User_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }


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




    }
}
