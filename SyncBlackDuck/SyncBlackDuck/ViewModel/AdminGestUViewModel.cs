using Sync_test;
using SyncBlackDuck.Services.Login;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{
    public class AdminGestUViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AdminGestUViewModel()
        {

        }

        // ICommands para las redirecciones de paginas
        public ICommand BackAdminMain => BackAdminMainP();

        // Metodos Command para hacer los metodos async
        private Command BackAdminMainP()
        {
            return new Command(async () => await BackAdminAsync());
        }
        private Task BackAdminAsync()
        {
            try
            {
                Application.Current.MainPage = new NavigationPage(new AdminMainPage());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cambiar de pagina");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
