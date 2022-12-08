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
        private bool IsGestionEnabled;
        private bool IsCerrarSesionEnabled;
        private bool IsBackAdminEnabled;

        public AdminVM(INavigation navigation)
        {
            Navigation = navigation;
            IsBackAdminEnabled = true;
            IsCerrarSesionEnabled = true;
            IsGestionEnabled = true;
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
                if (IsGestionEnabled == true)
                {
                    IsGestionEnabled = false;
                    // Redireccion usuarios
                    Navigation.PushAsync(new AdminGestClientPage());
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("El boton ya fue precionado", "Por favor espere", "Ok");
                    Task.Delay(4000);
                    IsGestionEnabled = true;
                }
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
                if (IsCerrarSesionEnabled == true)
                {
                    IsCerrarSesionEnabled = false;

                    Application.Current.Properties["id"] = 0;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("El boton ya fue precionado", "Por favor espere", "Ok");
                    Task.Delay(4000);
                    IsCerrarSesionEnabled = true;
                }
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
                if (IsBackAdminEnabled == true)
                {
                    IsBackAdminEnabled = false;

                    Navigation.PopAsync();
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("El boton ya fue precionado", "Por favor espere", "Ok");
                    Task.Delay(4000);
                    IsBackAdminEnabled = true;
                }

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
