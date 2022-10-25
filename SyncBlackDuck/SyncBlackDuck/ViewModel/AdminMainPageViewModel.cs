using Sync_test;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Login;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{
    internal class AdminMainPageViewModel : INotifyPropertyChanged
    {
        private string user_telefono;
        private user loggedInUser;

        public event PropertyChangedEventHandler PropertyChanged;
        public AdminMainPageViewModel()
        {
            _ = StartUp();
        }

        private async Task StartUp() => await Task.Run(() => Inicio());

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

        public int User_Telefono { get => User_Telefono; set => User_Telefono = value; }

        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

    }
}
