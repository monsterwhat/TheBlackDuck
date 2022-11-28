using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Views;
using SyncBlackDuck.Views.SuperAdminViews;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cSuperAdminViewModel
{
    public partial class SAdminVM : SAdminBaseVM
    {
        private int user_Telefono;
        private user loggedInUser;
        public SAdminVM(INavigation navigation) {

            Navigation = navigation;
        }
        public int User_Telefono { get => user_Telefono; set => user_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

        #region Commands
        public ICommand GestionAdministradores => GestionAdminPage();
        public ICommand SACSCerrarSesion => SACerrarSesion();
        public ICommand BackAdminMain => BackAdminMainP();

        private Command GestionAdminPage()
        {
            return new Command(async () => await GestionAdminPageAsync());
        }
        private Command SACerrarSesion()
        {
            return new Command(async () => await SACerrarSesionAsync());
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
                Navigation.PushAsync(new SuperAdminGestAdmin());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cerrar sesion");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        private Task SACerrarSesionAsync()
        {
            try
            {
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
        private Task BackAdminAsync()
        {
            try
            {
                Navigation.PushAsync(new SuperAdminMainPage());
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

    }
}

