using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using SyncBlackDuck.Views.AdminViews;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    internal class AdminUserGestViewModel : userImpl, INotifyPropertyChanged, IEditableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<user> listaUsuarios = new List<user>();
        /// <summary>
        /// Notificador de cambios
        /// </summary>
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        /// <summary>
        /// Lista de usuarios con notificaciones
        /// </summary>
        private ObservableCollection<user> usuariosInfo;
        public ObservableCollection<user> usuariosInfoCollection {
            get { return usuariosInfo; }
            set { this.usuariosInfo = value;
                RaisePropertyChanged("user");
            }
        }
        /// <summary>
        /// Cambios en la lista con notificaciones
        /// </summary>
        private ObservableCollection<object> selectedItems;
        public ObservableCollection<object> SelectedItems
        {
            get { return selectedItems; }
            set
            {
                this.selectedItems = value;
                //Se podria salvar para aplicar cambios en la BD....
                RaisePropertyChanged("SelectedItems");
            }
        }
        /// <summary>
        /// Inicializamos los observadores y cargamos la lista de clientes.
        /// </summary>
        public AdminUserGestViewModel()
        {
            usuariosInfo = new ObservableCollection<user>();
            selectedItems = new ObservableCollection<object>();
            CargarClientes();
        }

        // ICommands para las redirecciones de paginas
        public ICommand BackAdminMain => BackAdminMainP();

        // Metodos Command para hacer los metodos async
        private Command BackAdminMainP()
        {
            return new Command(async () => await BackAdminAsync());
        }
        /// <summary>
        /// Metodo para cargar los clientes en el observable collection
        /// </summary>
        private void CargarClientes()
        {
            try
            {
                //Cargamos la lista
                listaUsuarios = verClientes();
                //Iteramos para insertar en el observable collection
                for (int i = 0; i < listaUsuarios.Count; i++)
                {
                    usuariosInfo.Add(listaUsuarios.ElementAt(i));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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

        private Command agregarUsuario;
        public ICommand AgregarUsuario => agregarUsuario ??= new Command(PerformAgregarUsuario);

        private void PerformAgregarUsuario()
        {
            
        }

        private Command borrarUsuario;
        public ICommand BorrarUsuario => borrarUsuario ??= new Command(PerformBorrarUsuario);

        private void PerformBorrarUsuario()
        {
            
        }

        private Command salvar;
        public ICommand Salvar => salvar ??= new Command(PerformSalvar);

        private void PerformSalvar()
        {
            
        }

        private Dictionary<string, object> storedValues;


        public void BeginEdit()
        {
            this.storedValues = this.BackUp();
        }

        public void CancelEdit()
        {
            if (this.storedValues == null)
                return;

            foreach (var item in this.storedValues)
            {
                var itemProperties = this.GetType().GetTypeInfo().DeclaredProperties;
                var pDesc = itemProperties.FirstOrDefault(p => p.Name == item.Key);
                if (pDesc != null)
                    pDesc.SetValue(this, item.Value);
            }
        }

        public void EndEdit()
        {
            if (this.storedValues != null)
            {
                this.storedValues.Clear();
                this.storedValues = null;
            }
            Debug.WriteLine("End Edit Called");
        }

        protected Dictionary<string, object> BackUp()
        {
            var dictionary = new Dictionary<string, object>();
            var itemProperties = this.GetType().GetTypeInfo().DeclaredProperties;
            foreach (var pDescriptor in itemProperties)
            {
                if (pDescriptor.CanWrite)
                    dictionary.Add(pDescriptor.Name, pDescriptor.GetValue(this));
            }
            return dictionary;
        }

        private void DataGrid_CurrentCellBeginEdit(object sender, GridCurrentCellBeginEditEventArgs args)
        {
            // Editing prevented for the cell at RowColumnIndex(2,2).
            if (args.RowColumnIndex == new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(2, 2))
                args.Cancel = true;
        }

        private void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs args)
        {
            // Editing prevented for the cell at RowColumnIndex(1,3).
            if (args.RowColumnIndex == new Syncfusion.GridCommon.ScrollAxis.RowColumnIndex(1, 3))
                args.Cancel = true;
        }


    }
}