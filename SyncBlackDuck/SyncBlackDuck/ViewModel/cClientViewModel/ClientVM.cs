using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Views;
using SyncBlackDuck.Views.ClientViews;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cClientViewModel
{
    public partial class ClientVM : ClienteBaseVM
    {
        private int user_Telefono;
        private user loggedInUser;

        public ClientVM(INavigation navigation) {
            Navigation = navigation;
        }
        public int User_Telefono { get => user_Telefono; set => user_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

        #region Commands

        // ICommands para las redirecciones de paginas
        public ICommand CGestionUsuario => CGestionUsuarioPage();
        public ICommand CCSCerrarSesion => CCerrarSesion();
        public ICommand BackClientMain => BackClientMainP();

        // Metodos Command para hacer los metodos async
        private Command CGestionUsuarioPage()
        {
            return new Command(async () => await CGestionUsuarioAsync());
        }
        private Command CCerrarSesion()
        {
            return new Command(async () => await CCerrarSesionAsync());
        }
        private Command BackClientMainP()
        {
            return new Command(async () => await BackClientAsync());
        }
        private Task CGestionUsuarioAsync()
        {
            try
            {
                // Redireccion usuarios
                Navigation.PushAsync(new ClienteGestUPage());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cambiar de pagina");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        private Task CCerrarSesionAsync()
        {
            try
            {
                // Aqui hay que cerrar la sesion guardada
                Application.Current.Properties["id"] = 0;
                Navigation.PushAsync(new MainPage());
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
                Navigation.PushAsync(new ClienteMainPage());
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

    }
}
