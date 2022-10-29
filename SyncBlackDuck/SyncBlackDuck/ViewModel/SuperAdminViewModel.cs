using Sync_test;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{

    internal class SuperAdminViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public SuperAdminViewModel()
        {
            
        }

        // ICommands para las redirecciones de paginas
        public ICommand CerrarSesion => CerrarSesionSuperAdmin();

        // Metodos Command para hacer los metodos async
        private Command CerrarSesionSuperAdmin()
        {
            return new Command(async () => await CSSuperAdminAsync());
        }
        private Task CSSuperAdminAsync()
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
    }
}
