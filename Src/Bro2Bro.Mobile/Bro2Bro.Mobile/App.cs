using System;

using Bro2Bro.Mobile.Views;

using Xamarin.Forms;

namespace Bro2Bro.Mobile {
    public class App : Application {
        public static Guid UserGUID { get; set; }

        public App() {
            MainPage = new LoginPage();
        }
    }
}