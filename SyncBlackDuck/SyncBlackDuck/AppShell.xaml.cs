using Sync_test;
using Xamarin.Forms;

namespace SyncBlackDuck
{
   
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AdminMainPage), typeof(AdminMainPage));

        }
    }
}