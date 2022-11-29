﻿using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using Syncfusion.Data.Extensions;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cClientViewModel
{
    public partial class ClientGestVM : ClienteBaseVM
    {
        private User usuarioSeleccionado = new User();
        private List<User> listaUsuarios = new List<User>();
        private UserImpl userController = new UserImpl();
        public int row;
        public string Dato;
        public int UserID;

        public ClientGestVM(INavigation navigation, SfDataGrid datagrid)
        {
            Navigation = navigation;
            usuariosInfo = new ObservableCollection<User>();
            selectedItem = new Object();
            CargarClientes();
            datagrid.CurrentCellBeginEdit += DataGrid_CurrentCellBeginEdit;
            datagrid.CurrentCellEndEdit += DataGrid_CurrentCellEndEdit;
        }

        #region CellListeners

        public void DataGrid_CurrentCellBeginEdit(object sender, GridCurrentCellBeginEditEventArgs args)
        {
            row = args.RowColumnIndex.RowIndex;
            Dato = args.Column.MappingName;
            UserID = usuariosInfo.ElementAt(row - 1).User_id;
        }

        public void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs args)
        {
            bool Estado = false;
            if (args.OldValue != args.NewValue)
            {
                User UsuarioSelecionado = usuariosInfo.ElementAt(row - 1);
                Estado = userController.modificar(UsuarioSelecionado);
            }

        }

        #endregion CellListeners


        #region Listas

        private ObservableCollection<User> usuariosInfo;
        public ObservableCollection<User> usuariosInfoCollection
        {
            get { return usuariosInfo; }
            set
            {
                if (this.usuariosInfo != value)
                {
                    this.usuariosInfo = value;
                }
            }
        }

        private Object selectedItem;
        public Object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (this.selectedItem != value)
                {
                    this.selectedItem = value;
                    //Se podria salvar para aplicar cambios en la BD....
                    //Actualizar(value); //Donde value es el usuario (objeto) seleccionado.
                    //Despues de actualizar necesitamos recargar la tabla(?)
                }
            }
        }

        #endregion Listas


        #region Commands

        public ICommand BackClientMain => BackClientMainP();

        private Command BackClientMainP()
        {
            return new Command(async () => await BackClientAsync());
        }

        private Task BackClientAsync()
        {
            try
            {
                Navigation.PopAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cambiar de pagina");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        #endregion Commands
        
        private void CargarClientes()
        {
            try
            {
                var tel = Application.Current.Properties["id"] as string;
                listaUsuarios = userController.VerClienteEspecifico(int.Parse(tel));
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

    }
}
