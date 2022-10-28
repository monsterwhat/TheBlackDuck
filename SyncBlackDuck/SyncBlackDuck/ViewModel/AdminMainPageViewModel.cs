using Sync_test;
using SyncBlackDuck.Views.AdminViews;
using System;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Login;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{
    internal class AdminMainPageViewModel : INotifyPropertyChanged
    {
        private string user_telefono;
        private user loggedInUser;

        public event PropertyChangedEventHandler PropertyChanged;
        public int User_Telefono { get => User_Telefono; set => User_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

        public AdminMainPageViewModel()
        {
            _ = StartUp();
        }
        // ICommands para las redirecciones de paginas
        public ICommand GestionUsuarios => GestionUserPage();
        public ICommand CerrarSesion => CerrarSesionAdmin();


        // Metodos Command para hacer los metodos async
        private Command GestionUserPage()
        {
            return new Command(async () => await GestionUserAsync());
        }
        private Command CerrarSesionAdmin()
        {
            return new Command(async () => await CSAdminAsync());
        }
        private async Task StartUp() => await Task.Run(() => Inicio());

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
        private void Inicio()
        {
            try
            {
                if (Application.Current.Properties.ContainsKey("Id"))
                {
                    string Session = Application.Current.Properties["Id"] as string;
                    user_telefono = Session;
                    loginService login = new loginService();
                    loggedInUser = login.loginByPhone(Int32.Parse(user_telefono));
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error en Inicio");
            }

        }
    }
}
