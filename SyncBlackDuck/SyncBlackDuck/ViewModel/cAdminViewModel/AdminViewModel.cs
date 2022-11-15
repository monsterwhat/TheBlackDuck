<<<<<<< Updated upstream
﻿using Sync_test;
=======
﻿using SyncBlackDuck;
using SyncBlackDuck.Views.AdminViews;
using System;
>>>>>>> Stashed changes
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Views.AdminViews;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public partial class AdminViewModel : AdminBaseVM
    {
        private int user_Telefono;
        private user loggedInUser;
        
        public AdminViewModel(INavigation navigation){
            Navigation = navigation;
        }

        public int User_Telefono { get => user_Telefono; set => user_Telefono = value; }
        public user LoggedInUser { get => loggedInUser; set => loggedInUser = value; }

        #region Commands

        // ICommands para las redirecciones de paginas
        public ICommand GestionUsuarios => GestionUserPage();
        public ICommand CSCerrarSesion => CerrarSesion();
        public ICommand BackAdminMain => BackAdminMainP();

        // Metodos Command para hacer los metodos async
        private Command GestionUserPage()
        {
            return new Command(async () => await GestionUserAsync());
        }
        private Command CerrarSesion()
        {
            return new Command(async () => await CerrarSesionAsync());
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
<<<<<<< HEAD:SyncBlackDuck/SyncBlackDuck/ViewModel/AdminViewModel.cs
<<<<<<< Updated upstream
                App.Current.MainPage = new NavigationPage(new AdminGestUsuarios());
=======
                App.Current.MainPage = new NavigationPage(new Views.AdminViews.AdminGestionUsuarios());
>>>>>>> Stashed changes
=======
                Navigation.PushAsync(new AdminGestUsuarios());
>>>>>>> 83800c75de0d329474ac5128b2ca3a67fa77f28e:SyncBlackDuck/SyncBlackDuck/ViewModel/cAdminViewModel/AdminViewModel.cs
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error al cerrar sesion");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        private Task CerrarSesionAsync()
        {
            try
            {
                // Aqui hay que cerrar la sesion guardada
                Application.Current.Properties["id"] = 0;
<<<<<<< HEAD:SyncBlackDuck/SyncBlackDuck/ViewModel/AdminViewModel.cs
                App.Current.MainPage = new NavigationPage(new Views.AdminViews.MainPage());
=======
                Navigation.PushAsync(new MainPage());
>>>>>>> 83800c75de0d329474ac5128b2ca3a67fa77f28e:SyncBlackDuck/SyncBlackDuck/ViewModel/cAdminViewModel/AdminViewModel.cs
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
<<<<<<< HEAD:SyncBlackDuck/SyncBlackDuck/ViewModel/AdminViewModel.cs
                Application.Current.MainPage = new NavigationPage(new Views.AdminViews.AdminMainPage());
=======
                Navigation.PushAsync(new AdminMainPage());
>>>>>>> 83800c75de0d329474ac5128b2ca3a67fa77f28e:SyncBlackDuck/SyncBlackDuck/ViewModel/cAdminViewModel/AdminViewModel.cs
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

    }
}
