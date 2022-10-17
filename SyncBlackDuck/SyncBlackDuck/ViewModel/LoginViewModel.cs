using Sync_test;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{
    public class LoginViewModel 
    {
        public Command LoginCommand;

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => 
            await LoginAsync());
        }
        Task LoginAsync()
        {
            NavigationPage np = new NavigationPage(new MainPage());
            Application.Current.MainPage = np;
            return Task.CompletedTask;
        }
    }
}
