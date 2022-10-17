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

        public bool VerifyLogin()
        {
            try
            {

                int telefono = Convert.ToInt32(txt_telefono.Text);
                string password = txt_password.Text;

                if (!telefono.Equals(null))
                {
                    if (!password.Equals(null))
                    {
                        if (Login(telefono, password))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Login(int t, string p)
        {
            try
            {
                loginService login = new loginService();
                if (login.loginByRank(t, p))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;

            }
        }

        private void IngresoBtn_Clicked(object sender, EventArgs e)
        {
            if (VerifyLogin())
            {
                Navigation.PushModalAsync(new AdminMainPage());
            }
            else
            {

            }
        }

    }
}
