using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.ComboBox;
using Syncfusion.XForms.PopupLayout;
using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using StackLayout = Xamarin.Forms.StackLayout;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminUserGestVM : AdminBaseVM
    {
        private List<user> listaUsuarios = new List<user>();
        private userImpl userController = new userImpl();
        public user SwipedUser = new user();
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

        private string NewUsername;
        private string NewPassword;
        private int NewTelefono;
        private string NewRol;
        public string SelectedBoxItem;

        public AdminUserGestVM(INavigation navigation, SfDataGrid datagrid)
        {
            Navigation = navigation;
            usuariosInfo = new ObservableCollection<user>();
            selectedItem = new Object();
            popupLayout = new SfPopupLayout();
            CargarClientes();
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
            UserID = usuariosInfo.ElementAt(Row - 1).User_id;
        }

        public void DataGrid_CurrentCellEndEdit(object sender, GridCurrentCellEndEditEventArgs args)
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
                    user UsuarioSelecionado = usuariosInfo.ElementAt(Row - 1);
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

                    Estado = userController.modificar(UsuarioSelecionado);
                    Console.WriteLine("Modificar " + Tipo + " -> Estado: " + Estado);
                }
            }
            CeldaSeleccionada = false;
        }

        public void DataGrid_SwipeStarted(object sender, Syncfusion.SfDataGrid.XForms.SwipeStartedEventArgs args)
        {
            SwipedUser = args.RowData as user;
        }

        public DataTemplate RightSwipeTemplate() =>

            new DataTemplate(() =>
            {
                ContentView myView = new ContentView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.FromHex("#DC143C"),
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

        public void LoadPopUpAgregar()
        {
            this.UserInput = false;
            this.UserTelefono = false;
            this.UserPassword = false;
            this.NewUsername = null;
            this.NewPassword = null;
            this.NewTelefono = 0;

            if (!this.popupLayout.IsOpen)
            {
                this.popupLayout.IsOpen = true;
                this.popupLayout.Show();
            }

            this.popupLayout.PopupView.HeightRequest = 350;
            this.popupLayout.PopupView.ShowCloseButton = false;
            this.popupLayout.PopupView.AnimationMode = AnimationMode.SlideOnTop;

            var UserInput = new Entry()
            {
                TextColor = Color.Black,
                FontSize = 12,
                BackgroundColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                PlaceholderColor = Color.Gray,
                Placeholder = "Nombre de Usuario",
                Text = "",
                BindingContext = this
            };

            UserInput.Completed += UserInput_Completed;
            UserInput.Unfocused += UserInput_Completed;

            var UserName = new SfTextInputLayout()
            {
                Hint = "Nombre de Usuario",
                ErrorText = "El nombre de usuario no puede estar vacio",
                Margin = new Thickness(0, 5, 5, 0),
                InputView = UserInput
            };

            var PasswordInput = new Entry()
            {
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                FontSize = 12,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                PlaceholderColor = Color.Gray,
                Placeholder = "Password",
                Text = "",
                IsPassword = true,
                BindingContext = this
            };

            PasswordInput.Completed += PasswordInput_Completed;
            PasswordInput.Unfocused += PasswordInput_Completed;

            var UserPassword = new SfTextInputLayout()
            {
                Hint = "Password del Usuario",
                ErrorText = "El Password no puede estar vacio",
                Margin = new Thickness(0, 5, 5, 0),
                InputView = PasswordInput
            };

            var TelefonoInput = new Entry()
            {
                TextColor = Color.Black,
                FontSize = 12,
                BackgroundColor = Color.White,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                PlaceholderColor = Color.Gray,
                Placeholder = "Telefono del Usuario",
                Text = "",
                BindingContext = this,
                Keyboard = Keyboard.Numeric
            };

            TelefonoInput.Completed += TelefonoInput_Completed;
            TelefonoInput.Unfocused += TelefonoInput_Completed;

            var UserCell = new SfTextInputLayout()
            {
                Hint = "Telefono del Usuario",
                ErrorText = "El Telefono del usuario no puede estar vacio",
                Margin = new Thickness(0, 5, 5, 0),
                InputView = TelefonoInput
            };

            var headerTemplateView = new DataTemplate(() =>
            {
                headerContent = new Label()
                {
                    Text = "Agregar Usuario",
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.White,
                    BackgroundColor = Color.FromRgb(57, 62, 70),
                    FontSize = 16,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };
                return headerContent;
            });

            var stackLayout = new DataTemplate(() =>
                {
                    var stack = new StackLayout()
                    {
                        Margin = new Thickness(10),
                        Children =
                    {
                        new Label(){
                                    Text = "Ingrese los datos del Usuario",
                                    TextColor = Color.Black,
                                    BackgroundColor = Color.White,
                                    HorizontalTextAlignment = TextAlignment.Center,
                                    VerticalTextAlignment = TextAlignment.Center
                        },
                                    UserName,
                                    UserPassword,
                                    UserCell,
                    }
                    };
                    return stack;
                });

            var footerStack = new DataTemplate(() =>
                    {
                        var Stack = new StackLayout()
                        {
                            Margin = new Thickness(20),
                            Orientation = StackOrientation.Horizontal,
                            Children = {
                                new SfButton
                                {   Text = "Guardar",
                                    TextColor = Color.White,
                                    FontAttributes = FontAttributes.Bold,
                                    BackgroundColor = Color.FromHex("#87c38f"),
                                    HorizontalOptions = LayoutOptions.FillAndExpand,
                                    Command=AgregarUsuarioC()
                                    }
                                }
                        };
                        return Stack;
                    });

            this.popupLayout.PopupView.FooterTemplate = footerStack;
            this.popupLayout.PopupView.HeaderTemplate = headerTemplateView;
            this.popupLayout.PopupView.ContentTemplate = stackLayout;
        }

        public void LoadPopUpEliminar()
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
                popupContent.Text = "Desea Eliminar a '" + SwipedUser.User_name + "' ?";
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
                                            Command=BorrarUsuario}
                            }
                };

                return footerStack;
            });

            this.popupLayout.PopupView.ContentTemplate = templateView;
            this.popupLayout.PopupView.HeaderTemplate = headerTemplateView;
            this.popupLayout.PopupView.FooterTemplate = footerTemplateView;
        }

        public void DataGrid_SwipeEnded(object sender, Syncfusion.SfDataGrid.XForms.SwipeEndedEventArgs args)
        {
            double fullswipe;
            fullswipe = args.SwipeOffset;
            if (fullswipe.Equals(-200))
            {
                LoadPopUpEliminar();
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

        #endregion Listas

        #region Commands

        private Command agregarUsuario;
        public ICommand AgregarUsuario => agregarUsuario ??= new Command(PerformAgregarUsuario);

        private void PerformAgregarUsuario()
        {
            LoadPopUpAgregar();
        }

        private Command recargar;

        public ICommand Recargar => recargar ??= new Command(ExecutePullToRefreshCommand);

        private void ExecutePullToRefreshCommand()
        {
            CargarClientes();
        }

        #region Inputs

        private void UserInput_Completed(object sender, EventArgs e)
        {
            var text = ((Entry)sender).Text;
            Console.WriteLine("UserInput_Completed: " + text);
            this.NewUsername = text;
            this.UserInput = true;
        }

        private void PasswordInput_Completed(object sender, EventArgs e)
        {

            var text = ((Entry)sender).Text;
            Console.WriteLine("PasswordInput_Completed: " + text);
            this.NewPassword = text;
            this.UserPassword = true;
        }

        private void TelefonoInput_Completed(object sender, EventArgs e)
        {

            var text = ((Entry)sender).Text;
            Console.WriteLine("PasswordInput_Completed: " + text);
            this.NewTelefono = int.Parse(text);
            this.UserTelefono = true;
        }

        #endregion Inputs

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

        public ICommand AgregarUsuariocommand => AgregarUsuarioC();

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
                    user NuevoUsuario = new user()
                    {
                        User_name = NewUsername,
                        User_password = NewPassword,
                        User_telefono = NewTelefono,
                    };

                    bool Agregado = userController.insertarNuevoC(NuevoUsuario);

                    Cancelar();

                    Console.WriteLine("Se agrego el Usuario: " + Agregado);
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
                        IsOpen = true,
                        PopupView = ErrorPopUp
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
                usuariosInfo.Clear();
                listaUsuarios.Clear();

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