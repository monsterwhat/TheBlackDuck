using SyncBlackDuck.ViewModel.cAdminViewModel;
using SyncBlackDuck.ViewModel.cClientViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncBlackDuck.Views.ClientViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClienteGestUPage : ContentPage
    {
        public ClienteGestUPage()
        {
            InitializeComponent();
            BindingContext = new ClientGestVM(Navigation, this.dataGrid);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            GC.Collect();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}