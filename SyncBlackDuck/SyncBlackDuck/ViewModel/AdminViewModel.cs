using Sync_test;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Implementaciones;
using SyncBlackDuck.Services.Login;
using SyncBlackDuck.Views.AdminViews;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel
{
    internal class AdminViewModel : INotifyPropertyChanged
    {
        private string user_telefono;
        private user loggedInUser;
        private userImpl userImpl;

        public event PropertyChangedEventHandler PropertyChanged;
        public int User_Telefono { get => User_Telefono; set => User_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

        public AdminViewModel()
        {
            // PARA EL DATATABLE TEMPORAL
            user = new ObservableCollection<user>();
            this.GenerarUsuarios();
        }
        // ICommands para las redirecciones de paginas
        public ICommand GestionUsuarios => GestionUserPage();
        public ICommand CerrarSesion => CerrarSesionAdmin();
        public ICommand BackAdminMain => BackAdminMainP();

        // Metodos Command para hacer los metodos async
        private Command GestionUserPage()
        {
            return new Command(async () => await GestionUserAsync());
        }
        private Command CerrarSesionAdmin()
        {
            return new Command(async () => await CSAdminAsync());
        }
        private Command BackAdminMainP()
        {
            return new Command(async () => await BackAdminAsync());
        }
        private Task GestionUserAsync()
        {
            try
            {
                // Redireccion usuarios
                App.Current.MainPage = new NavigationPage(new AdminGestUsuarios());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cerrar sesion");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        private Task CSAdminAsync()
        {
            try
            {
                // Aqui hay que cerrar la sesion guardada
                Application.Current.Properties["id"] = 0;
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cerrar sesion");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
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

        // TEMPORAL PARA VISUALIZAR DATOS EN EL DATAGRID
        private ArrayList listaUsuarios;

        private ObservableCollection<user> user;
        public ObservableCollection<user> userInfoCollection
        {
            get { return user; }
            set { this.user = value; }
        }

        private void GenerarUsuarios()
        {

            listaUsuarios = new ArrayList();
            
            user.Add(new user(1001, "Maria Anders", "12314", DateTime.Now, 88888888, "admin"));
            user.Add(new user(1001, "Maria Anders", "12314", DateTime.Now, 88888888, "admin"));
            user.Add(new user(1001, "Maria Anders", "12314", DateTime.Now, 88888888, "admin"));

            /*
            listaUsuarios = userImpl.verTodo();
            foreach (user item in listaUsuarios)
            {
                user.Add(item);

            }
            */
        }
    }
}
