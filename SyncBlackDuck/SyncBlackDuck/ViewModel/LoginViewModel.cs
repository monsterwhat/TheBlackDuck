using Sync_test;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Login;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{
    public class LoginViewModel : loginService
    {
        public Command LoginCommand;
        private int telefono;
        private string password;

        //Getters y setters para los bindings de la vista
        public int Telefono { get => telefono; set => telefono = value; }
        public string Password { get => password; set => password = value; }

        public LoginViewModel()
        {

        }
        
        //Binding del boton login en la vista
        public ICommand Login => LoginCommand = new Command(async () =>
            await LoginAsync());

        //Metodo Async para iniciar sesion
        Task LoginAsync()
        {
            user loggedInUser = loginByRank(Telefono, Password);
            switch (loggedInUser.User_rol)
            {
                case "admin":
                    //Redireccion admin
                    App.Current.MainPage = new NavigationPage(new AdminMainPage());
                    break;
                case "superadmin":
                    //Redireccion superAdmin
                    App.Current.MainPage = new NavigationPage(new AdminMainPage());
                    break;
                case null:
                    //Mostrar error de login
                    break;
                default:
                    //Deberia ser cliente
                    App.Current.MainPage = new NavigationPage(new AdminMainPage());
                    break;

            }
            //Fin metodo Async
            return Task.CompletedTask;
        }
    }
}
