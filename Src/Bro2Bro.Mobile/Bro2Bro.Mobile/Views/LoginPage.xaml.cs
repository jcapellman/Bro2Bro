using System;

using Xamarin.Forms;

using Bro2Bro.Mobile.ViewModels;

namespace Bro2Bro.Mobile.Views {
    public partial class LoginPage : ContentPage {
        private LoginModel viewModel => (LoginModel)BindingContext;

        public LoginPage() {
            InitializeComponent();

            BindingContext = new LoginModel();

            btnLogin.Clicked += btnLogin_Clicked;
        }

        public async void btnLogin_Clicked(object sender, EventArgs e) {
            var result = await viewModel.AttemptLogin();

            if (!result) {
                await DisplayAlert("Bro2Bro", "Sorry bro, those ain't the right credz try again.", "OK");
                return;
            }

            await Navigation.PushAsync(new MainPage());
        }
    }
}