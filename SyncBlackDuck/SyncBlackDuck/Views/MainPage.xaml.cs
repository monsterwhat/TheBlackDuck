using Syncfusion.XForms.TextInputLayout;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TheBlackDuck.Models.Implementations;
using SyncBlackDuck.Services;

namespace Sync_test
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {

        }

        public int VerifyLogin()
        {
            try
            {

                int telefono = Convert.ToInt32(txt_telefono.Text);
                string password = txt_password.Text;

                if (!telefono.Equals(null))
                {
                    if (!password.Equals(null))
                    {
                        switch (Login(telefono, password))
                        {
                            case "cliente":
                                return 1;
                            case "admin":
                                return 2;
                            case "superadmin":
                                return 3;
                            default:
                                DisplayAlert("Error", "La contraseña es incorrecta", "OK");
                                return 0;
                        }
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public String Login(int t, string p)
        {
            try
            {
                loginService login = new loginService();
                string rank = login.loginByRank(t, p);
                if (rank != null)
                {
                    return rank;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;

            }
        }

        private void IngresoBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                int rank = VerifyLogin();
                switch (rank)
                {
                    case 1:
                        //Navigation.PushModalAsync(new ClientePage());
                        break;
                    case 2:
                        Navigation.PushModalAsync(new AdminMainPage());
                        break;
                    case 3:
                        //Navigation.PushModalAsync(new SuperAdminPage());
                        break;
                    default:
                        DisplayAlert("Error", "El usuario no existe", "OK");
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
