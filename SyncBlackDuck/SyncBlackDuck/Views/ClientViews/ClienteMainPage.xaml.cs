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
    public partial class ClienteMainPage : ContentPage
    {
        public ClienteMainPage()
        {
            InitializeComponent();
            BindingContext = new ClientVM(Navigation);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BindingContext = null;
            GC.Collect();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ClientVM(Navigation);
            GC.Collect();
        }
    }
}