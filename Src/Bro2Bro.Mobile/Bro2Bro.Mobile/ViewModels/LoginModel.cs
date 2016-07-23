using Bro2Bro.PCL.Handlers;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bro2Bro.Mobile.ViewModels {
    public class LoginModel : BaseModel {
        private string _username;

        public string Username {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); checkButton(); }
        }

        private string _password;

        public string Password {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); checkButton(); }
        }

        private bool _enableLoginButton;

        public bool EnableLoginButton {
            get { return _enableLoginButton; }
            set { _enableLoginButton = value; OnPropertyChanged(); }
        }

        private bool _enableRunningIndicator;

        public bool EnableRunningIndicator {
            get { return _enableRunningIndicator; }
            set { _enableRunningIndicator = value;  OnPropertyChanged(); }
        }

        private bool _enableRemember;

        public bool EnableRemember {
            get { return _enableRemember; }
            set { _enableRemember = value;  OnPropertyChanged(); }
        }

        private void checkButton() {
            EnableLoginButton = !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        } 
        
        public LoginModel() {
            Username = string.Empty;
            Password = string.Empty;

            EnableRunningIndicator = false;
            EnableRemember = true;
            EnableLoginButton = false;
        }

        public async Task<string> AttemptLogin() {
            try {
                var response = string.Empty;

                EnableLoginButton = false;

                EnableRunningIndicator = true;

                var authHandler = new AuthHandler();

                var result = await authHandler.CheckAuth(Username, Password);

                if (result.HasValue) {
                    App.UserGUID = result.Value;
                } else {
                    response = "Sorry bro, not the right credz.";
                }

                EnableRunningIndicator = false;
                EnableLoginButton = true;

                return response;
            } catch (Exception ex) {
                EnableLoginButton = true;
                EnableRunningIndicator = false;

                return ex.ToString();
            }
        }
    }
}