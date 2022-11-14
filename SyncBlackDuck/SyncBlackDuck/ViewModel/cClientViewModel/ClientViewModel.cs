using Sync_test;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Views.AdminViews;
using SyncBlackDuck.Views.ClientViews;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cClientViewModel
{
    public partial class ClientViewModel : ClienteBaseVM
    {
        private string user_telefono;
        private user loggedInUser;

        public ClientViewModel(INavigation navigation) {
            Navigation = navigation;
        }
        public int User_Telefono { get => User_Telefono; set => User_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

        // ICommands para las redirecciones de paginas
        public ICommand GestionUsuario => GestionUsuarioPage();
        public ICommand CSCerrarSesion => CerrarSesion();
        public ICommand BackClientMain => BackClientMainP();

        // Metodos Command para hacer los metodos async
        private Command GestionUsuarioPage()
        {
            return new Command(async () => await GestionUsuarioAsync());
        }
        private Command CerrarSesion()
        {
            return new Command(async () => await CerrarSesionAsync());
        }
        private Command BackClientMainP()
        {
            return new Command(async () => await BackClientAsync());
        }
        private Task GestionUsuarioAsync()
        {
            try
            {
                // Redireccion usuarios
                Application.Current.MainPage = new NavigationPage(new ClienteGestUPage());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cambiar de pagina");
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
        private Task BackClientAsync()
        {
            try
            {
                Application.Current.MainPage = new NavigationPage(new ClienteMainPage());
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
