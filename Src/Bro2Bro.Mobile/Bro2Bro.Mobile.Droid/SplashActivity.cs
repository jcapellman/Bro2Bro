using Android.App;

using Bro2Bro.Mobile.Views;

namespace Bro2Bro.Mobile.Droid {
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity {
        protected override void OnResume() {
            base.OnResume();

            StartActivity(typeof(MainActivity));            
        }
    }
}