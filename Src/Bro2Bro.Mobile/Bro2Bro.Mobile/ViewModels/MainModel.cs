using Bro2Bro.PCL.Handlers;
using Bro2Bro.PCL.Transports.Messages;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bro2Bro.Mobile.ViewModels {
    public class MainModel : BaseModel {
        private List<MessageGroupListingResponseItem> _messages;

        public List<MessageGroupListingResponseItem> Messages {
            get { return _messages; }
            set { _messages = value;  OnPropertyChanged(); }
        }

        public MainModel() { Messages = new List<MessageGroupListingResponseItem>(); }

        public async Task<string> LoadData() {
            try {
                var messageHandler = new MessageHandler(App.UserGUID);

                var result = await messageHandler.GetListing();
                
                Messages = result;

                return string.Empty;
            } catch (Exception ex) {
                return ex.ToString();
            }
        }
    }
}