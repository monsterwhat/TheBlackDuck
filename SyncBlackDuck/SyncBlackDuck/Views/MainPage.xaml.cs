using Xamarin.Forms;
using SyncBlackDuck.ViewModel;

namespace Sync_test
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.LoginViewModel = new LoginViewModel();
            this.BindingContext = LoginViewModel;
        }
        public LoginViewModel LoginViewModel { get; set; }

        /*private void IngresoBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AdminMainPage());
        }*/
    }
}