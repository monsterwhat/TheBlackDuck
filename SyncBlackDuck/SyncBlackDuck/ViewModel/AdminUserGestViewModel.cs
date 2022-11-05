using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{
    internal class AdminUserGestViewModel : userImpl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private user usuarioSeleccionado;
        private List<user> listaUsuarios = new List<user>();

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public List<user> ListaUsuarios { get { return listaUsuarios; } set { listaUsuarios = value; OnPropertyChanged(nameof(ListaUsuarios)); } }
        public user UsuarioSeleccionado { get { return usuarioSeleccionado; } set { usuarioSeleccionado = value; OnPropertyChanged(nameof(usuarioSeleccionado)); } }

        public AdminUserGestViewModel()
        {
            listaUsuarios = CargarClientes();
        }

        private List<user> CargarClientes()
        {
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

        private Command agregarUsuario;
        public ICommand AgregarUsuario => agregarUsuario ??= new Command(PerformAgregarUsuario);

        private void PerformAgregarUsuario()
        {
        }

        private Command modificarUsuario;
        public ICommand ModificarUsuario => modificarUsuario ??= new Command(PerformModificarUsuario);

        private void PerformModificarUsuario()
        {
        }

        private Command borrarUsuario;
        public ICommand BorrarUsuario => borrarUsuario ??= new Command(PerformBorrarUsuario);

        private void PerformBorrarUsuario()
        {
        }

        private Command backAdminMain;
        public ICommand BackAdminMain => backAdminMain ??= new Command(PerformBackAdminMain);

        private void PerformBackAdminMain()
        {
        }
    }
}