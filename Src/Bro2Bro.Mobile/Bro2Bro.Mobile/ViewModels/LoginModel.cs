using Bro2Bro.PCL.Handlers;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bro2Bro.Mobile.ViewModels {
    public class LoginModel : INotifyPropertyChanged {
        private string _username;

        public string Username {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;

        public string Password {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public async Task<bool> AttemptLogin() {
            var authHandler = new AuthHandler();

            var result = await authHandler.CheckAuth(Username, Password);

            if (result.HasValue) {
                App.UserGUID = result.Value;
            }

            return result.HasValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}