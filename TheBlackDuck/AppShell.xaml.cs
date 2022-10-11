using System;
using System.Collections.Generic;
using TheBlackDuck.Views;
using Xamarin.Forms;

namespace TheBlackDuck
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
