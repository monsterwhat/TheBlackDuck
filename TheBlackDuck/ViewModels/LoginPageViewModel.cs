using System;
using System.Collections.Generic;
using System.Text;

namespace TheBlackDuck.ViewModels
{
    internal class LoginPageViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginPageViewModel()
        {
            Username = "admin";
            Password = "admin";
        }
        
            

    }
}
