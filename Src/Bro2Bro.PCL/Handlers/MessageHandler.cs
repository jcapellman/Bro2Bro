using Bro2Bro.PCL.Transports.Messages;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bro2Bro.PCL.Handlers {
    public class MessageHandler : BaseHandler {
        protected override string BaseControllerName() => "Message";

        public MessageHandler(Guid guid) : base(guid) { }

        public async Task<bool> AddMessage(MessageRequestItem requestItem) => await PutAsync<MessageRequestItem, bool>(requestItem);

        public async Task<List<MessageGroupListingResponseItem>> GetListing() => await GetAsync<List<MessageGroupListingResponseItem>>();
    }
}