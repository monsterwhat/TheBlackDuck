using SyncBlackDuck.Views.AdminViews;
using System;
using SyncBlackDuck.Model.Objetos;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminVM : AdminBaseVM
    {
        private int user_Telefono;
        private user loggedInUser;
        
        public AdminVM(INavigation navigation){
            Navigation = navigation;
        }

        public int User_Telefono { get => user_Telefono; set => user_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

        #region Commands

        // ICommands para las redirecciones de paginas
        public ICommand GestionUsuarios => GestionUserPage();
        public ICommand CSCerrarSesion => CerrarSesion();
        public ICommand BackAdminMain => BackAdminMainP();

        // Metodos Command para hacer los metodos async
        private Command GestionUserPage()
        {
            return new Command(async () => await GestionUserAsync());
        }
        private Command CerrarSesion()
        {
            return new Command(async () => await CerrarSesionAsync());
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
                App.Current.MainPage = new NavigationPage(new AdminGestClientPage());
                App.Current.MainPage = new NavigationPage(new Views.AdminViews.AdminGestClientPage());
                Navigation.PushAsync(new AdminGestClientPage());
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
                App.Current.MainPage = new NavigationPage(new Views.AdminViews.AdminMainPage());
                Navigation.PushAsync(new AdminMainPage());
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
                Application.Current.MainPage = new NavigationPage(new Views.AdminViews.AdminMainPage());
                Navigation.PushAsync(new AdminMainPage());
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
