﻿using Sync_test;
using SyncBlackDuck.Model.Objetos;
using SyncBlackDuck.Services.Login;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace SyncBlackDuck.ViewModel
{
    internal class LoginViewModel : loginService, INotifyPropertyChanged
    {
        private int telefono;
        private string password;
        //Creamos el Objeto Usuario
        private user loggedInUser;
        private string userId;

        public event PropertyChangedEventHandler PropertyChanged;

        //Getters y setters para los bindings de la vista
        public int Telefono { get => telefono; set => telefono = value; }
        public string Password { get => password; set => password = value; }

        public LoginViewModel()
        {
           AsyncSession();
        }

        //Binding del boton login en la vista
        public ICommand Login => LoginCommand();


        private Command LoginCommand()
        {
            return new Command(async () => await LoginAsync());
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
                        loggedInUser = loginByPhone(int.Parse(userId));
                        LoginCommand();
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
                    loggedInUser = loginByRank(Telefono, Password);
                    Application.Current.Properties["id"] = loggedInUser.User_telefono.ToString();

                }

                switch (loggedInUser.User_rol)
                {
                    case "admin":
                        //Redireccion admin
                        App.Current.MainPage = new NavigationPage(new AdminMainPage());
                        break;
                    case "superadmin":
                        //Redireccion superAdmin
                        App.Current.MainPage = new NavigationPage(new AdminMainPage());
                        break;
                    case null:
                        //Mostrar error de login
                        break;
                    default:
                        //Deberia ser cliente
                        App.Current.MainPage = new NavigationPage(new AdminMainPage());
                        break;

                }
                //Fin metodo Async
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error en LoginAsync");
                return Task.CompletedTask;

            }
        }

    }
}