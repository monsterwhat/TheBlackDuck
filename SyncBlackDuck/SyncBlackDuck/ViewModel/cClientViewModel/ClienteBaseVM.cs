using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cClientViewModel
{
    public class ClienteBaseVM : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}