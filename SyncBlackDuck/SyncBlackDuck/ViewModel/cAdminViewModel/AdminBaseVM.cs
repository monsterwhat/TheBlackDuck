using SyncBlackDuck.Model.Objetos;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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