using SyncBlackDuck.Model.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public class AdminBaseVM : INotifyPropertyChanged
    {
        public user loggedInUser = new user();
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}