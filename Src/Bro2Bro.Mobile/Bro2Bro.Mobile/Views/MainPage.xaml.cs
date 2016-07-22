using Bro2Bro.Mobile.ViewModels;

using Xamarin.Forms;

namespace Bro2Bro.Mobile.Views {
    public partial class MainPage : ContentPage {
        public MainModel viewModel => (MainModel)BindingContext;

        public MainPage() {
            InitializeComponent();

            BindingContext = new MainModel();
        }

        protected override void OnBindingContextChanged() {
            viewModel.LoadData();
        }
    }
}