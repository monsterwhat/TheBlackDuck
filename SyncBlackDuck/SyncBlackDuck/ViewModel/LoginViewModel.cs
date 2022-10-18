using Sync_test;
using SyncBlackDuck.Services;
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

        public int Telefono { get => telefono; set => telefono = value; }
        public string Password { get => password; set => password = value; }

        public LoginViewModel()
        {
            
        }

        public ICommand Login => LoginCommand = new Command(async () =>
            await LoginAsync());

        Task LoginAsync()
        {
            switch (loginByRank(Telefono, Password))
            {
                case "admin":
                    App.Current.MainPage = new NavigationPage(new AdminMainPage());
                    break;
                case "superadmin":
                    App.Current.MainPage = new NavigationPage(new AdminMainPage());
                    break;
                case "na":
                    App.Current.MainPage = new NavigationPage(new AdminMainPage());
                    break;
                case "error":
                    App.Current.MainPage = new NavigationPage(new AdminMainPage());
                    break;
                default:
                    App.Current.MainPage = new NavigationPage(new AdminMainPage());
                    break;

            }
            return Task.CompletedTask;
        }
    }
}
