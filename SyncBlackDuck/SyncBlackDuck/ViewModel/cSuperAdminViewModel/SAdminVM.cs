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
        private User loggedInUser;
        private bool GestionAdministradoresEstado;
        private bool SACSCerrarSessionEstado;
        private bool SBackAdminMainEstado;
        public SAdminVM(INavigation navigation) {

            Navigation = navigation;
            GestionAdministradoresEstado = true;
            SACSCerrarSessionEstado = true;
            SBackAdminMainEstado = true;
        }
        public int User_Telefono { get => user_Telefono; set => user_Telefono = value; }
        public User LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

        #region Commands

        // ICommand a Async

        public ICommand GestionAdministradores => GestionAdminPage();
        public ICommand SACSCerrarSesion => SACerrarSesion();
        public ICommand BackAdminMain => BackAdminMainP();

        // ICommand Async a metodos

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

        // Metodos

        private Task GestionAdminPageAsync()
        {
            try
            {
                if (GestionAdministradoresEstado == true)
                {
                    GestionAdministradoresEstado = false;
                    // Redireccion usuarios
                    Navigation.PushAsync(new SuperAdminGestAdmin());
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("El boton ya fue precionado", "Por favor espere", "Ok");
                    Task.Delay(4000);
                    GestionAdministradoresEstado = true;
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
        private Task SACerrarSesionAsync()
        {
            try
            {
                if(SACSCerrarSessionEstado == true){
                    SACSCerrarSessionEstado = false;
                    
                    Application.Current.Properties["id"] = 0;
                    Navigation.PushAsync(new MainPage());
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("El boton ya fue precionado", "Por favor espere", "Ok");
                    Task.Delay(4000);
                    SACSCerrarSessionEstado = true;
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
                if(SBackAdminMainEstado == true)
                {
                    SBackAdminMainEstado = false;
                    Navigation.PushAsync(new SuperAdminMainPage());
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("El boton ya fue precionado", "Por favor espere", "Ok");
                    Task.Delay(4000);
                    SBackAdminMainEstado = true;
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

        #endregion commands

    }
}

