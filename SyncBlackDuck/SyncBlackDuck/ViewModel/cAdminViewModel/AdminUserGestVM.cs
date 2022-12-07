using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using SyncBlackDuck.Views.AdminViews;
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
using Windows.ApplicationModel.UserDataTasks;
using Xamarin.Forms;
using StackLayout = Xamarin.Forms.StackLayout;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminUserGestVM : AdminBaseVM
    {
        private List<User> listaUsuarios = new List<User>();
        private readonly UserImpl userController = new UserImpl();
        public User SwipedUser = new User();
        public int SelectedIndex;
        public SfDataGrid userGrid;
        public int Row;
        public string Dato;
        public int UserID;
        public SfPopupLayout popupLayout;
        public DataTemplate headerTemplateView;
        public DataTemplate templateView;
        public DataTemplate footerTemplateView;
        public Label headerContent;
        public Label popupContent;
        public bool UserInput = false;
        public bool UserPassword = false;
        public bool UserTelefono = false;
        public bool userRol = false;
        public bool CeldaSeleccionada = false;
        public int swipedUserID;
        private string NewUsername;
        private string NewPassword;
        private int NewTelefono;
        public string SelectedBoxItem;

        public AdminUserGestVM(INavigation navigation, SfDataGrid datagrid)
        {
            Navigation = navigation;
            usuariosInfo = new ObservableCollection<User>();
            selectedItem = new Object();
            popupLayout = new SfPopupLayout();
            CargarClientes();
            datagrid.CurrentCellBeginEdit += DataGrid_CurrentCellBeginEdit;
            datagrid.CurrentCellEndEdit += DataGrid_CurrentCellEndEdit;
            datagrid.PullToRefreshCommand = Recargar;
            datagrid.SwipeOffsetMode = SwipeOffsetMode.Custom;
            datagrid.MaxSwipeOffset = 200;
            datagrid.SwipeStarted += DataGrid_SwipeStarted;
            datagrid.SwipeEnded += DataGrid_SwipeEnded;
            datagrid.RightSwipeTemplate = RightSwipeTemplate();
            datagrid.LeftSwipeTemplate = LeftSwipeTemplate();
        }

        #region CellListeners

        public void DataGrid_CurrentCellBeginEdit(object sender, GridCurrentCellBeginEditEventArgs args)
        {
            CeldaSeleccionada = true;
            GetDatosCelda(args.RowColumnIndex.RowIndex, args.Column.MappingName);
        }

        public void GetDatosCelda(int row, string dato)
        {
            Row = row;
            Dato = dato;
            UserID = usuariosInfo.ElementAt(Row - 1).User_id;
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
                        User UsuarioSelecionado = usuariosInfo.ElementAt(Row - 1);
                        switch (Tipo)
                        {
                            case "User_name":
                                UsuarioSelecionado.User_name = ValorNuevo.ToString();
                                break;
                            case "User_password":
                                UsuarioSelecionado.User_password = ValorNuevo.ToString();
                                break;
                            case "User_telefono":
                                UsuarioSelecionado.User_telefono = Convert.ToInt32(ValorNuevo);
                                break;
                            case "User_rol":
                                UsuarioSelecionado.User_rol = ValorNuevo.ToString();
                                break;
                        }

                        Estado = userController.Modificar(UsuarioSelecionado);
                        Console.WriteLine("Modificar " + Tipo + " -> Estado: " + Estado);
                        ExecutePullToRefreshCommand();

                    }
                }
                CeldaSeleccionada = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DataGrid_SwipeStarted(object sender, Syncfusion.SfDataGrid.XForms.SwipeStartedEventArgs args)
        {
            try
            {
                SwipedUser = args.RowData as User;
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

        public DataTemplate LeftSwipeTemplate() =>

            new DataTemplate(() =>
            {
                ContentView myView = new ContentView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.FromHex("#04adff"),
                    Padding = 9,
                };

                var label = new Label()
                {
                    Text = "Ver mas",
                    TextColor = Color.White,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Start,
                    FontSize = 15
                };

                myView.Content = label;

                return myView;
            });

        public Task LoadPopUpAgregar()
        {
            try
            {
                this.UserInput = false;
                this.UserTelefono = false;
                this.UserPassword = false;
                this.NewUsername = null;
                this.NewPassword = null;
                this.NewTelefono = 0;

                this.popupLayout.PopupView.ShowFooter = false;
                this.popupLayout.PopupView.ShowHeader = false;
                this.popupLayout.PopupView.HeightRequest = 350;
                this.popupLayout.PopupView.ShowCloseButton = false;
                this.popupLayout.PopupView.AnimationMode = AnimationMode.SlideOnTop;

                #region Inputs

                var UserInput = new Entry()
                {
                    TextColor = Color.White,
                    FontSize = 12,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    PlaceholderColor = Color.Gray,
                    Placeholder = "Nombre de Usuario",
                    Text = "",
                    BindingContext = this
                };

                var PasswordInput = new Entry()
                {
                    TextColor = Color.White,
                    FontSize = 12,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    PlaceholderColor = Color.Gray,
                    Placeholder = "Password",
                    Text = "",
                    IsPassword = true,
                    BindingContext = this
                };

                var TelefonoInput = new SfNumericTextBox()
                {
                    AllowDefaultDecimalDigits = false,
                    EnableGroupSeparator = false,
                    MaximumNumberDecimalDigits = 0,
                    AllowNull = true,
                    TextColor = Color.White,
                    FontSize = 12,
                    BindingContext = this
                };

                #endregion Inputs

                #region Events

                UserInput.Completed += UserInput_Completed;
                UserInput.Unfocused += UserInput_Completed;
                PasswordInput.Completed += PasswordInput_Completed;
                PasswordInput.Unfocused += PasswordInput_Completed;
                TelefonoInput.Completed += TelefonoInput_Completed;
                TelefonoInput.Unfocused += TelefonoInput_Completed;

                #endregion Events

                #region Containers

                var UserName = new SfTextInputLayout()
                {
                    ContainerType = ContainerType.Filled,
                    Hint = "Nombre de Usuario",
                    ErrorText = "El nombre de usuario no puede estar vacio",
                    ErrorColor = Color.FromHex("#B00020"),
                    FocusedColor = Color.FromHex("#00afb2"),
                    UnfocusedColor = Color.FromHex("#C9D6DF"),
                    Margin = new Thickness(5, 5, 20, 5),
                    InputView = UserInput,
                    LeadingView = new Image()
                    {
                        Source = "https://cdn-icons-png.flaticon.com/512/747/747545.png",
                        HeightRequest = 20
                    },
                };

                var UserPassword = new SfTextInputLayout()
                {
                    ContainerType = ContainerType.Filled,
                    Hint = "Contraseña del Usuario",
                    ErrorText = "La contraseña no puede estar vacio",
                    ErrorColor = Color.FromHex("#B00020"),
                    UnfocusedColor = Color.FromHex("#C9D6DF"),
                    FocusedColor = Color.FromHex("#00afb2"),
                    Margin = new Thickness(5, 5, 20, 5),
                    InputView = PasswordInput,
                    LeadingView = new Image()
                    {
                        Source = "https://cdn-icons-png.flaticon.com/512/4686/4686696.png",
                        HeightRequest = 20
                    }
                };


                var UserCell = new SfTextInputLayout()
                {
                    ContainerType = ContainerType.Filled,
                    Hint = "Telefono del Usuario",
                    ErrorText = "El Telefono del usuario no puede estar vacio",
                    ErrorColor = Color.FromHex("#B00020"),
                    FocusedColor = Color.FromHex("#00afb2"),
                    UnfocusedColor = Color.FromHex("#C9D6DF"),
                    Margin = new Thickness(5, 5, 20, 0),
                    InputView = TelefonoInput,
                    LeadingView = new Image()
                    {
                        Source = "https://cdn-icons-png.flaticon.com/512/4504/4504935.png",
                        HeightRequest = 20
                    }
                };

                #endregion Containers

                #region Body

                var stackLayout = new DataTemplate(() =>
                {
                    var stack = new StackLayout()
                    {
                        BackgroundColor = Color.FromHex("#283149"),
                        Margin = new Thickness(10),
                        Children =
                        {
                        new Label()
                            {
                            Text = "Agregar Usuario",
                            HeightRequest = 40,
                            FontAttributes = FontAttributes.Bold,
                            TextColor = Color.White,
                            BackgroundColor = Color.FromRgb(57, 62, 70),
                            FontSize = 16,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center
                            },
                        UserName,
                        UserPassword,
                        UserCell,
                        new SfButton
                            {
                            Margin = new Thickness(20,0,20,10),
                            Text = "Guardar",
                            CornerRadius = 10,
                            TextColor = Color.White,
                            FontAttributes = FontAttributes.Bold,
                            BackgroundColor = Color.FromHex("#04adff"),
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Command=AgregarUsuarioC()
                            }
                        }
                    };
                    return stack;
                });

                this.popupLayout.PopupView.ContentTemplate = stackLayout;

                #endregion Body

                if (!this.popupLayout.IsOpen)
                {
                    this.popupLayout.IsOpen = true;
                    this.popupLayout.Show();
                }

                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Task.CompletedTask;
            }
        }

        public Task LoadPopUpEliminar()
        {
            try
            {
                this.popupLayout.PopupView.ShowHeader = true;
                this.popupLayout.PopupView.ShowFooter = true;
                this.popupLayout.PopupView.HeightRequest = 200;
                this.popupLayout.PopupView.ShowCloseButton = false;
                this.popupLayout.PopupView.AnimationMode = AnimationMode.SlideOnRight;

                var headerTemplateView = new DataTemplate(() =>
                {
                    headerContent = new Label
                    {
                        Text = "Confirmacion de Eliminacion",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.White,
                        BackgroundColor = Color.FromRgb(57, 62, 70),
                        FontSize = 16,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center
                    };
                    return headerContent;
                });

                var templateView = new DataTemplate(() =>
                {
                    popupContent = new Label
                    {
                        Text = "Desea Eliminar a '" + SwipedUser.User_name + "' ?",
                        TextColor = Color.Black,
                        BackgroundColor = Color.White,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center
                    };
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
                                            Command=BorrarUsuario}
                            }
                    };

                    return footerStack;
                });

                this.popupLayout.PopupView.ContentTemplate = templateView;
                this.popupLayout.PopupView.HeaderTemplate = headerTemplateView;
                this.popupLayout.PopupView.FooterTemplate = footerTemplateView;

                if (!this.popupLayout.IsOpen)
                {
                    this.popupLayout.IsOpen = true;
                    this.popupLayout.Show();
                }
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Task.CompletedTask;
            }
        }

        public void DataGrid_SwipeEnded(object sender, Syncfusion.SfDataGrid.XForms.SwipeEndedEventArgs args)
        {
            try
            {
                double fullswipe;
                fullswipe = args.SwipeOffset;
                if (args.SwipeDirection == Syncfusion.SfDataGrid.XForms.SwipeDirection.Left && fullswipe.Equals(-200))
                {
                    LoadPopUpEliminar();
                }
                else if (args.SwipeDirection == Syncfusion.SfDataGrid.XForms.SwipeDirection.Right && fullswipe.Equals(200))
                {

                    string swipedID = SwipedUser.User_id.ToString();
                    swipedUserID = int.Parse(swipedID);
                    GestionPagos();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion CellListeners

        #region Listas

        private ObservableCollection<User> usuariosInfo;
        public ObservableCollection<User> UsuariosInfoCollection
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
                }
            }
        }
        public int SwipedUserID
        {
            get { return swipedUserID; }
            set
            {
                if (this.swipedUserID != value)
                {
                    this.swipedUserID = value;
                }
            }
        }

        #endregion Listas

        #region Inputs

        private void UserInput_Completed(object sender, EventArgs e)
        {
            try
            {
                var text = ((Entry)sender).Text;
                if (!text.Equals(null) || !text.Equals(""))
                {
                    Console.WriteLine("UserInput_Completed: " + text);
                    this.NewUsername = text;
                    this.UserInput = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void PasswordInput_Completed(object sender, EventArgs e)
        {
            try
            {
                var text = ((Entry)sender).Text;
                if (!text.Equals(null) || !text.Equals(""))
                {
                    Console.WriteLine("PasswordInput_Completed: " + text);
                    this.NewPassword = text;
                    this.UserPassword = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        private void TelefonoInput_Completed(object sender, EventArgs e)
        {
            try
            {
                object value = ((SfNumericTextBox)sender).Value.ToString();
                if (!value.Equals(null) || !value.Equals(""))
                {
                    Console.WriteLine("PasswordInput_Completed: " + value);
                    int Telefono = Convert.ToInt32(value);
                    this.NewTelefono = Telefono;
                    this.UserTelefono = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        #endregion Inputs

        #region Commands

        // Path ICommands a Meodos

        public ICommand BackAdminMain => BackAdminMainP();
        public ICommand AgregarUsuariocommand => AgregarUsuarioC();
        public ICommand AgregarUsuario => PerformAgregarUsuario();
        public ICommand Recargar => ExecutePullToRefreshCommand();
        public ICommand BorrarUsuario => PerformBorrarUsuario();
        public ICommand CancelarComando => Cancelar();

        // Perform Metodos
        private Command PerformAgregarUsuario()
        {
            return new Command(async () => PerformAgregarUsuarioT());
        }
        private void PerformAgregarUsuarioT()
        {
            LoadPopUpAgregar();
        }
        
        private Command ExecutePullToRefreshCommand()
        {
            return new Command(async () => ExecutePullToRefreshCommandT());
        }
        private void ExecutePullToRefreshCommandT()
        {
            CargarClientes();
        }
        
        private Command PerformBorrarUsuario()
        {
            return new Command(async () => await PerformBorrarUsuarioT());
        }
        private Task PerformBorrarUsuarioT()
        {
            try
            {
                bool Eliminado = userController.Eliminar(SwipedUser);
                Console.WriteLine("Elimar userId: " + SwipedUser.User_id + "Estado : " + Eliminado);
                this.popupLayout.IsOpen = false;
                this.popupLayout.Dismiss();
                ExecutePullToRefreshCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Task.CompletedTask;
        }
        
        private Command Cancelar()
        {
            return new Command(async () => CancelarT());
        }
        private void CancelarT()
        {
            try
            {
                this.popupLayout.IsOpen = false;
                this.popupLayout.Dismiss();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        private Command AgregarUsuarioC()
        {
            return new Command(async () => await AgregarUsuarioT());
        }
        private Task AgregarUsuarioT()
        {
            try
            {
                if (this.UserInput != false && this.UserPassword != false && this.UserTelefono != false)
                {
                    User NuevoUsuario = new User()
                    {
                        User_name = NewUsername,
                        User_password = NewPassword,
                        User_telefono = NewTelefono,
                        User_estado = "Activo"
                    };

                    bool Agregado = userController.InsertarNuevoC(NuevoUsuario);

                    Cancelar();

                    Console.WriteLine("Se agrego el Usuario: " + Agregado);
                    ExecutePullToRefreshCommand();

                }
                else
                {
                    var ErrorPopUp = new PopupView()
                    {
                        ShowHeader = false,
                        ShowCloseButton = false,
                        IsVisible = true,
                        ContentTemplate = new DataTemplate(() =>
                        {
                            return new Label()
                            {
                                Text = "Debe llenar todos los campos",
                                TextColor = Color.Black,
                                BackgroundColor = Color.White,
                                HorizontalTextAlignment = TextAlignment.Center,
                                VerticalTextAlignment = TextAlignment.Center
                            };
                        }),
                    };

                    new SfPopupLayout()
                    {
                        PopupView = ErrorPopUp,
                        IsOpen = true
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al agregar usuario");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        #endregion commands

        // Redirecciones
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

        private Task GestionPagos()
        {
            try
            {
                Navigation.PushAsync(new AdminGestPagosPage(swipedUserID));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Task.CompletedTask;
        }
        private Task CargarClientes()
        {
            try
            {
                usuariosInfo.Clear();
                listaUsuarios.Clear();

                listaUsuarios = userController.VerClientes();
                for (int i = 0; i < listaUsuarios.Count; i++)
                {
                    usuariosInfo.Add(listaUsuarios.ElementAt(i));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Task.CompletedTask;
        }
    }
}