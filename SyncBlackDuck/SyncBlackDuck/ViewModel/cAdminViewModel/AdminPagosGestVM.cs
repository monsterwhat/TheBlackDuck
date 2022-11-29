using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.SfNumericTextBox.XForms;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.PopupLayout;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminPagosGestVM : AdminBaseVM
    {
        private List<pagos> listaPagos = new List<pagos>();
        private pagosImpl pagosController = new pagosImpl();
        public int Row;
        public pagos SwipedPago = new user();
        public string Dato;
        public int PagoID;
        public SfPopupLayout popupLayout;
        public bool CeldaSeleccionada = false;
        public DataTemplate headerTemplateView;
        public DataTemplate templateView;
        public DataTemplate footerTemplateView;
        public Label headerContent;
        public Label popupContent;


        public AdminPagosGestVM(INavigation navigation, SfDataGrid datagrid)
        {
            Navigation = navigation;
            pagosInfo = new ObservableCollection<pagos>();
            selectedItem = new Object();
            popupLayout = new SfPopupLayout();
            CargarPagos();
            datagrid.CurrentCellBeginEdit += DataGrid_CurrentCellBeginEdit;
            datagrid.CurrentCellEndEdit += DataGrid_CurrentCellEndEdit;
            datagrid.SwipeEnded += DataGrid_SwipeEnded;
            datagrid.SwipeOffsetMode = SwipeOffsetMode.Custom;
            datagrid.MaxSwipeOffset = 200;
            datagrid.SwipeStarted += DataGrid_SwipeStarted;
            datagrid.PullToRefreshCommand = Recargar;
            datagrid.RightSwipeTemplate = RightSwipeTemplate();
        }

        #region CellListeners

        public void DataGrid_CurrentCellBeginEdit(object sender, GridCurrentCellBeginEditEventArgs args)
        {
            CeldaSeleccionada = true;
            getDatosCelda(args.RowColumnIndex.RowIndex, args.Column.MappingName);
        }

        public void getDatosCelda(int row, string dato)
        {
            Row = row;
            Dato = dato;
            PagoID = pagosInfo.ElementAt(Row - 1).Pagos_id;
        }

        public void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs args)
        {
            try
            {
                if (CeldaSeleccionada == true)
                {
                    bool Estado = false;
                    var Tipo = Dato;
                    //Usando mapping name se puede haccer
                    var ValorViejo = args.OldValue;
                    var ValorNuevo = args.NewValue;
                    
                    if (!ValorNuevo.Equals(ValorViejo))
                    {
                        pagos PagoSelecionado = pagosInfo.ElementAt(Row - 1);
                        switch (Tipo)
                        {
                            case "Pagos_estado":
                                PagoSelecionado.Pagos_estado = (int)ValorNuevo;
                                break;
                        }

                        Estado = pagosController.modificar(PagoSelecionado);
                        Console.WriteLine("Modificar " + Tipo + " -> Estado: " + Estado);
                    }
                }
                CeldaSeleccionada = false;
            }
            catch (Exception e) {
                Console.WriteLine(e); 
            }
        }

        public void DataGrid_SwipeStarted(object sender, Syncfusion.SfDataGrid.XForms.SwipeStartedEventArgs args)
        {
            try
            {
                SwipedPago = args.RowData as pagos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public DataTemplate RightSwipeTemplate() =>

            new DataTemplate(() =>
            {
                ContentView myView = new ContentView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.FromHex("#540712"),
                    Padding = 9,
                };

                var label = new Label()
                {
                    Text = "Borrar",
                    TextColor = Color.White,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                    FontSize = 15
                };

                myView.Content = label;

                return myView;
            });

        public void LoadPopUpEliminar()
        {
            try
            {

                this.popupLayout.PopupView.HeightRequest = 200;
                this.popupLayout.PopupView.ShowCloseButton = false;
                this.popupLayout.PopupView.AnimationMode = AnimationMode.SlideOnRight;

                if (!this.popupLayout.IsOpen)
                {
                    this.popupLayout.IsOpen = true;
                    this.popupLayout.Show();
                }

                var headerTemplateView = new DataTemplate(() =>
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

                var templateView = new DataTemplate(() =>
                {
                    popupContent = new Label();
                    popupContent.Text = "Desea Eliminar al ID '" + SwipedPago.Pagos_id + "' ?";
                    popupContent.TextColor = Color.Black;
                    popupContent.BackgroundColor = Color.White;
                    popupContent.HorizontalTextAlignment = TextAlignment.Center;
                    popupContent.VerticalTextAlignment = TextAlignment.Center;
                    return popupContent;
                });

                var footerTemplateView = new DataTemplate(() =>
                {
                    StackLayout footerStack = new StackLayout()
                    {
                        Margin = new Thickness(20),
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                                new Button {Text = "Eliminar",
                                            TextColor = Color.White,
                                            FontAttributes = FontAttributes.Bold,
                                            BackgroundColor = Color.FromRgb(179, 58, 58),
                                            HorizontalOptions = LayoutOptions.FillAndExpand,
                                            Command=BorrarPago}
                            }
                    };

                    return footerStack;
                });

                this.popupLayout.PopupView.ContentTemplate = templateView;
                this.popupLayout.PopupView.HeaderTemplate = headerTemplateView;
                this.popupLayout.PopupView.FooterTemplate = footerTemplateView;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DataGrid_SwipeEnded(object sender, Syncfusion.SfDataGrid.XForms.SwipeEndedEventArgs args)
        {
            try
            {
                double fullswipe;
                fullswipe = args.SwipeOffset;
                if (fullswipe.Equals(-200))
                {
                    LoadPopUpEliminar();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion CellListeners

        #region Listas

        private ObservableCollection<pagos> pagosInfo;
        public ObservableCollection<pagos> PagosInfoCollection
        {
            get { return pagosInfo; }
            set
            {
                if (this.pagosInfo != value)
                {
                    Console.WriteLine(value);
                    Console.WriteLine("se modifico el OC de pagosCollection");
                    this.pagosInfo = value;
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
                }
            }
        }

        #endregion Lista

        #region Commands

        private Command borrarPago;

        public ICommand BorrarPago => borrarPago ?? (borrarPago = new Command(() => BorrarPagoExecute()));

        private void BorrarPagoExecute()
        {
            try
            {
                bool Eliminado = pagosController.eliminar(SwipedPago);
                Console.WriteLine("Elimar pagoId: " + SwipedPago.Pagos_id + "Estado : " + Eliminado);
                this.popupLayout.IsOpen = false;
                this.popupLayout.Dismiss();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private Command recargar;

        public ICommand Recargar => recargar ??= new Command(ExecutePullToRefreshCommand);

        private void ExecutePullToRefreshCommand()
        {
            CargarPagos();
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

        #endregion Commands

        private void CargarPagos()
        {
            try
            {
                listaPagos.Clear();
                pagosInfo.Clear();

                listaPagos = pagosController.verPendientes();
                for (int i = 0; i < listaPagos.Count; i++)
                {
                    pagosInfo.Add(listaPagos.ElementAt(i));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}