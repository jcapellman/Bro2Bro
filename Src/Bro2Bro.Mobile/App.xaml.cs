using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Bro2Bro.Mobile.Services;
using Bro2Bro.Mobile.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Bro2Bro.Mobile
{
    public partial class App : Application
    {
        public static string ProductionBackendUrl = "http://localhost:5000";

        public static string BroId = string.Empty;

        public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
            {
                DependencyService.Register<MockDataStore>();
            }
            else
            {
                DependencyService.Register<ProductionDataStore>();
            }

            MainPage = new MainPage();
        }
    }
}