using System;

using Xamarin.Forms;

using Bro2Bro.Mobile.ViewModels;

namespace Bro2Bro.Mobile.Views {
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();

            BindingContext = new LoginModel();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e) {
            var result = await ((LoginModel)BindingContext).AttemptLogin();

            if (!string.IsNullOrEmpty(result)) {
                await DisplayAlert("Bro2Bro", result, "OK");
                return;
            }

            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }
    }
}