using Bro2Bro.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bro2Bro.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindBrosPage : ContentPage
    {
        public FindBrosPage()
        {
            InitializeComponent();

            BindingContext = new FindBrosViewModel();
        }
    }
}