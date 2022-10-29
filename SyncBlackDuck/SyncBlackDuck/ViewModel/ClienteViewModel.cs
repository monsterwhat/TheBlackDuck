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
    internal class ClienteViewModel : INotifyPropertyChanged
    {
        public ClienteViewModel()
        {

        }

        // ICommands para las redirecciones de paginas
        public ICommand CerrarSesion => CerrarSesionCliente();

        public event PropertyChangedEventHandler PropertyChanged;

        // Metodos Command para hacer los metodos async
        private Command CerrarSesionCliente()
        {
            return new Command(async () => await CSClienteAsync());
        }
        private Task CSClienteAsync()
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
