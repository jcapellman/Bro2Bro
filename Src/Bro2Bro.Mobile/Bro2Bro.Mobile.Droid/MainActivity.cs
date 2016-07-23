using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Bro2Bro.Mobile.Droid {
    [Activity(ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new Bro2Bro.Mobile.App());
        }
    }
}