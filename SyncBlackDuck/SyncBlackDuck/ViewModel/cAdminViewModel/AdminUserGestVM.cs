using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminUserGestVM : AdminBaseVM
    {
        private List<user> listaUsuarios = new List<user>();
        private userImpl userController = new userImpl();
        user SwipedUser = new user();
        public int SelectedIndex;
        public SfDataGrid userGrid;
        public int Row;
        public string Dato;
        public int UserID;
        SfPopupLayout popupLayout;
        DataTemplate headerTemplateView;
        DataTemplate templateView;
        DataTemplate footerTemplateView;
        Label footerContent;
        Label headerContent;
        Label popupContent;
        Button footerDelete;
        Button footerCancel;

        public AdminUserGestVM(INavigation navigation, SfDataGrid datagrid)
        {
            Navigation = navigation;
            usuariosInfo = new ObservableCollection<user>();
            selectedItem = new Object();
            CargarClientes();
            datagrid.CurrentCellBeginEdit += DataGrid_CurrentCellBeginEdit;
            datagrid.CurrentCellEndEdit += DataGrid_CurrentCellEndEdit;
            datagrid.SwipeEnded += DataGrid_SwipeEnded;
            datagrid.SwipeStarted += DataGrid_SwipeStarted;
            popupLayout = new SfPopupLayout();
        }

        #region CellListeners

        public void DataGrid_CurrentCellBeginEdit(object sender, GridCurrentCellBeginEditEventArgs args)
        {
            getDatosCelda(args.RowColumnIndex.RowIndex, args.Column.MappingName);
        }

        public Task getDatosCelda(int row, string dato)
        {
            Row = row;
            Dato = dato;
            UserID = usuariosInfo.ElementAt(Row - 1).User_id;
            return Task.CompletedTask;
        }

        public void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs args)
        {
            bool Estado = false;
            if (args.OldValue != args.NewValue)
            {
                user UsuarioSelecionado = usuariosInfo.ElementAt(Row - 1);
                Estado = userController.modificar(UsuarioSelecionado);
                Console.WriteLine("Modificar -> Estado: " + Estado);
            }
        }

        public void DataGrid_SwipeStarted(object sender, Syncfusion.SfDataGrid.XForms.SwipeStartedEventArgs args)
        {
            SwipedUser = args.RowData as user;
        }

        public void DataGrid_SwipeEnded(object sender, Syncfusion.SfDataGrid.XForms.SwipeEndedEventArgs args){
            double fullswipe;
            fullswipe = args.SwipeOffset;
            if (fullswipe.Equals(-200))
            {
                {
                    if (!this.popupLayout.IsOpen)
                    {
                        this.popupLayout.IsOpen = true;
                        this.popupLayout.Show();
                    }
                    this.popupLayout.PopupView.HeaderTemplate = headerTemplateView = new DataTemplate(() =>
                    {
                        headerContent = new Label();
                        headerContent.Text = "Confirmacion de Eliminacion";
                        headerContent.FontAttributes = FontAttributes.Bold;
                        headerContent.TextColor = Color.White;
                        headerContent.BackgroundColor = Color.FromRgb(57, 62, 70);
                        headerContent.FontSize = 16;
                        headerContent.HorizontalTextAlignment = TextAlignment.Center;
                        headerContent.VerticalTextAlignment = TextAlignment.Center;
                        return headerContent;
                    });
                    this.popupLayout.PopupView.ContentTemplate = templateView = new DataTemplate(() =>
                    {
                        popupContent = new Label();
                        popupContent.Text = "Desea Eliminar a '" + SwipedUser.User_name + "' ?";
                        popupContent.TextColor = Color.Black;
                        popupContent.BackgroundColor = Color.White;
                        popupContent.HorizontalTextAlignment = TextAlignment.Center;
                        popupContent.VerticalTextAlignment = TextAlignment.Center;
                        return popupContent;
                    });
                    this.popupLayout.PopupView.FooterTemplate = footerTemplateView = new DataTemplate(() =>
                    {
                        StackLayout footerStack = new StackLayout()
                        {
                            Margin = new Thickness(20),
                            Orientation = StackOrientation.Horizontal,
                            Children = {
                                new Button {Text = "Eliminar",TextColor = Color.White, FontAttributes = FontAttributes.Bold, BackgroundColor = Color.FromRgb(179, 58, 58),HorizontalOptions = LayoutOptions.FillAndExpand, Command=BorrarUsuario}
                            }
                        };

                        return footerStack;
                    });
                    this.popupLayout.PopupView.AnimationMode = AnimationMode.SlideOnRight;
                }
            }
        }

        #endregion CellListeners

        #region Listas

        private ObservableCollection<user> usuariosInfo;
        public ObservableCollection<user> usuariosInfoCollection
        {
            get { return usuariosInfo; }
            set
            {
                if (this.usuariosInfo != value)
                {
                    Console.WriteLine(value);
                    Console.WriteLine("se modifico el OC de userCollection");
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
                Console.WriteLine(value);
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

        private Command agregarUsuario;
        public ICommand AgregarUsuario => agregarUsuario ??= new Command(PerformAgregarUsuario);

        private void PerformAgregarUsuario()
        {

        }

        private Command borrarUsuario;
        public ICommand BorrarUsuario => borrarUsuario ??= new Command(PerformBorrarUsuario);

        private void PerformBorrarUsuario()
        {
            bool Eliminado = userController.eliminar(SwipedUser);
            Console.WriteLine("Elimar userId: " + SwipedUser.User_id + "Estado : " + Eliminado);
            this.popupLayout.IsOpen = false;
            this.popupLayout.Dismiss();
        }

        private Command cancelarComando;
        public ICommand CancelarComando => cancelarComando ??= new Command(Cancelar);

        private void Cancelar()
        {
            this.popupLayout.IsOpen = false;
            this.popupLayout.Dismiss();
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

        #endregion commands

        private void CargarClientes()
        {
            try
            {
                listaUsuarios = userController.verClientes();
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