using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBlackDuck.Models.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheBlackDuck.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {

        }

        public bool VerifyLogin()
        {
            try {

                int telefono = Convert.ToInt32(txt_Telefono.Text);
                string password = txt_Password.Text;

                if (!telefono.Equals(null))
                {
                    if (!password.Equals(null))
                    {
                        if(Login(telefono, password))
                        {
                            return true;
                        }
                    }
                }
                return false;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Login(int t, string p)
        {
            try
            {
                ClientesDAOImpl clientes = new ClientesDAOImpl();
                if(clientes.Login(t, p))
                {
                    return true;
                }
                return false;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;

            }
        }

        private void btn_login_Clicked(object sender, EventArgs e)
        {
            if (VerifyLogin())
            {
                Navigation.PushAsync(new MenuPage());
            }
            else
            {

            }

        }
    }
}