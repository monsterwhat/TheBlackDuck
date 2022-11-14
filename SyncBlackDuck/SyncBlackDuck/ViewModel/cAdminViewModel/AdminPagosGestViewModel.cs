using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminPagosGestViewModel : AdminBaseVM
    {
        private user usuarioSeleccionado;
        private List<pagos> listaPagos = new List<pagos>();
        private pagosImpl pagosController = new pagosImpl();

        public AdminPagosGestViewModel(INavigation navigation)
        {
            Navigation = navigation;
            pagosInfo = new ObservableCollection<pagos>();
            listaPagos = CargarPagos();
        }

        private ObservableCollection<pagos> pagosInfo;
        public ObservableCollection<pagos> PagosInfoCollection
        {
            get { return pagosInfo; }
            set{ this.pagosInfo = value; }
        }
        
        public List<pagos> ListaPagos { get { return listaPagos; } set { listaPagos = value; OnPropertyChanged(nameof(ListaPagos)); } }
        public user UsuarioSeleccionado { get { return usuarioSeleccionado; } set { usuarioSeleccionado = value; OnPropertyChanged(nameof(usuarioSeleccionado)); } }

        private List<pagos> CargarPagos()
        {
            try
            {
                listaPagos = pagosController.verTodo();
                for (int i = 0; i < listaPagos.Count; i++)
                {
                    pagosInfo.Add(listaPagos.ElementAt(i));
                }

                return pagosController.verTodo();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}