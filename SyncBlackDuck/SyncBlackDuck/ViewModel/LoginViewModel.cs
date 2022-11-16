using SyncBlackDuck;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Login;
using SyncBlackDuck.Views.AdminViews;
using SyncBlackDuck.Views.ClientViews;
using SyncBlackDuck.Views.SuperAdminViews;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace SyncBlackDuck.ViewModel
{
    public class LoginViewModel : ContentPage
    {
        private int telefono;
        private string password;
        //Creamos el Objeto Usuario
        private user loggedInUser;
        private string userId;
        private loginService loginController = new loginService();
        public INavigation Navigation;

        //Getters y setters para los bindings de la vista
        public int Telefono { get => telefono; set => telefono = value; }
        public string Password { get => password; set => password = value; }

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            AsyncCommand();
        }

        //Binding del boton login en la vista
        public ICommand Login => LoginCommand();

        private Command LoginCommand()
        {
            return new Command(async () => await LoginAsync());
        }

        private Command AsyncCommand()
        {
            return new Command(async () => await AsyncSession());
        }

        //Metodo Async para guardar la informacion del usuario
        private Task AsyncSession()
        {
            try
            {
                //Revisamos si ya existe una session guardada
                if (Application.Current.Properties.ContainsKey("id"))
                {
                    var id = Application.Current.Properties["id"] as string;
                    //Guardamos la session
                    userId = id;
                    if (userId != null || !userId.Equals(0))
                    {
                        loggedInUser = loginController.loginByPhone(int.Parse(userId));
                        new Command(async () => await LoginAsync());
                        /* Aqui si encuentra el usuario, deberia redireccionar al
                           main page de cada usuario por medio de un if, que revise
                           el tipo de rol y a partir de este, lo mande a su respectivo
                           main page */
                    }
                }
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error en AsyncSession");
                return Task.CompletedTask;
            }
        }
        //Metodo Async para iniciar sesion
        private Task LoginAsync()
        {
            try
            {
                if(loggedInUser == null)
                {
                    loggedInUser = loginController.loginByRank(Telefono, Password);
                    Application.Current.Properties["id"] = loggedInUser.User_telefono.ToString();
                }

                switch (loggedInUser.User_rol)
                {
                    case "admin":
                        //Redireccion admin
<<<<<<< HEAD
                        App.Current.MainPage = new NavigationPage(new Views.AdminViews.AdminMainPage());
=======
                         Navigation.PushAsync(new AdminMainPage());
>>>>>>> 83800c75de0d329474ac5128b2ca3a67fa77f28e
                        break;
                    case "superadmin":
                        //Redireccion superAdmin
                         Navigation.PushAsync(new SuperAdminMainPage());
                        break;
                    case null:
                        //Mostrar error de login
                        break;
                    default:
                        //Deberia ser cliente
                         Navigation.PushAsync(new ClienteMainPage());
                        break;

                }
                //Fin metodo Async
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Credenciales Incorrectas", "Numero de telefono o contraseña incorrecta", "Ok");
                Console.WriteLine(e);
                Console.WriteLine("Error en LoginAsync");
                return Task.CompletedTask;

            }
        }

    }
}
