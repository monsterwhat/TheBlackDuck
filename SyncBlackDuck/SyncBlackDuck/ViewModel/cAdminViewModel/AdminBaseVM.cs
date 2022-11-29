using SyncBlackDuck.Model.Objetos;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace SyncBlackDuck.ViewModel.cAdminViewModel
{
    public class AdminBaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void RaisePropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}