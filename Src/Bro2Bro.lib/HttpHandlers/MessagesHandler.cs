using System.Collections.Generic;
using System.Threading.Tasks;

using Bro2Bro.lib.DAL;
using Bro2Bro.lib.HttpHandlers.Base;

namespace Bro2Bro.lib.HttpHandlers
{
    public class MessagesHandler : BaseHttpHandler
    {
        public MessagesHandler(string baseWebServiceUrl) : base(baseWebServiceUrl)
        {
        }

        public async Task<List<Messages>> GetMessagesAsync(string senderBroId, string receiverBroId) =>
            await GetAsync<List<Messages>>("Messages", senderBroId, receiverBroId);
    }
}