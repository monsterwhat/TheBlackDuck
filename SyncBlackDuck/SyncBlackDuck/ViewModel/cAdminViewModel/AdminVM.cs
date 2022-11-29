using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Views;
using SyncBlackDuck.Views.AdminViews;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminVM : AdminBaseVM
    {
        private int user_Telefono;
        private User loggedInUser;
        public AdminVM(INavigation navigation)
        {
            Navigation = navigation;
        }
        public int User_Telefono { get => user_Telefono; set => user_Telefono = value; }
        public User LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

        #region Commands

        // Path ICommands a Async

        public ICommand ADGestionUsuarios => GestionUserPage();
        public ICommand ADCSCerrarSesion => ADCerrarSesion();
        public ICommand BackAdminMain => BackAdminMainP();

        // ICommand Async a Metodo
        private Command GestionUserPage()
        {
            return new Command(async () => await GestionUserAsync());
        }
        private Command ADCerrarSesion()
        {
            return new Command(async () => await ADCerrarSesionAsync());
        }
        private Command BackAdminMainP()
        {
            return new Command(async () => await BackAdminAsync());
        }

        // Metodos.redirecciones

        private Task GestionUserAsync()
        {
            try
            {
                // Redireccion usuarios
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

        private Task ADCerrarSesionAsync()
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
                Navigation.PopAsync();
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
