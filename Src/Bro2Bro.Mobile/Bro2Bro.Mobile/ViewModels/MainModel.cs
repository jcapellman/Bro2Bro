using Bro2Bro.PCL.Handlers;
using Bro2Bro.PCL.Transports.Messages;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bro2Bro.Mobile.ViewModels {
    public class MainModel : INotifyPropertyChanged {
        private ObservableCollection<MessageGroupListingResponseItem> _messages;

        public ObservableCollection<MessageGroupListingResponseItem> Messages {
            get { return _messages; }
            set { _messages = value;  OnPropertyChanged(); }
        }

        public MainModel() { }

        public async void LoadData() {
            var messageHandler = new MessageHandler(App.UserGUID);

            var result = await messageHandler.GetListing();

            Messages = new ObservableCollection<MessageGroupListingResponseItem>(result);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}