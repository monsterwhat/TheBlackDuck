using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using SyncBlackDuck.Views.AdminViews;
using SyncBlackDuck.Views.ClientViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cClientViewModel
{
 internal class ClientGestViewModel : userImpl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<object> _selectedItems;
        private user usuarioSeleccionado = new user();
        private List<user> listaUsuario = new List<user>();

        public List<user> ListaUsuario { get { return listaUsuario; } set { listaUsuario = value; OnPropertyChanged(nameof(ListaUsuario)); } }
        public user UsuarioSeleccionado { get { return usuarioSeleccionado; } set { usuarioSeleccionado = value; OnPropertyChanged(nameof(usuarioSeleccionado)); } }

        public ClientGestViewModel()
        {
            listaUsuario = cargarCliente();
        }

        // ICommands para las redirecciones de paginas
        public ICommand BackClientMain => BackClientMainP();

        // Metodos Command para hacer los metodos async
        private Command BackClientMainP()
        {
            return new Command(async () => await BackClientAsync());
        }

        // Para ver el historial de pagos del usuario
        private List<user> cargarCliente()
        { 
            /* Se debe hacer un metodo que retorne
           los datos del cliente especifico conectado */
            try
            {
                return verClientes();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private Task BackClientAsync()
        {
            try
            {
                Application.Current.MainPage = new NavigationPage(new ClienteMainPage());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cambiar de pagina");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public ObservableCollection<object> SelectedItems
        {
            get { return _selectedItems; }
            set { this._selectedItems = value; OnPropertyChanged("SelectedItems"); }
        }

    }
}
