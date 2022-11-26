using SyncBlackDuck.ViewModel.cClientViewModel;
using System;

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