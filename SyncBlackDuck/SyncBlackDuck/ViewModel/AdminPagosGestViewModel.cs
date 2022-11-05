using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{
    internal class AdminPagosGestViewModel : pagosImpl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private user usuarioSeleccionado;
        private List<pagos> listaPagos = new List<pagos>();

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public List<pagos> ListaPagos { get { return listaPagos; } set { listaPagos = value; OnPropertyChanged(nameof(ListaPagos)); } }
        public user UsuarioSeleccionado { get { return usuarioSeleccionado; } set { usuarioSeleccionado = value; OnPropertyChanged(nameof(usuarioSeleccionado)); } }

        public AdminPagosGestViewModel()
        {
            listaPagos = CargarPagos();
        }

        private List<pagos> CargarPagos()
        {
            try
            {
                return verTodo();
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

    }
}