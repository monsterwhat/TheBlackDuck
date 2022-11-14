using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace SyncBlackDuck.Droid
{
    [Activity(Label = "BlackDuck", Icon = "@drawable/icono",
     Theme = "@style/splashScreen",
     MainLauncher = true, NoHistory =true,
     ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}