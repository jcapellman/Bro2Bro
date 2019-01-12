using Bro2Bro.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bro2Bro.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindBros : ContentView
    {
        public FindBros()
        {
            InitializeComponent();

            BindingContext = new FindBrosViewModel();
        }
    }
}