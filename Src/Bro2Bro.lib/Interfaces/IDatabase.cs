using System.Collections.Generic;

using Bro2Bro.lib.DAL;
using Bro2Bro.lib.Transports;

namespace Bro2Bro.lib.Interfaces
{
    public interface IDatabase
    {
        List<Bros> GetBros(string searchQuery);

        bool RegisterBro(string broId, string displayName);

        bool ClearBros();

        List<Messages> GetMessages(string senderBroId, string receiverBroId);

        bool SendMessage(string senderBroId, string receiverBroId, string content);

        List<MessageThreadListingResponseItem> GetMessageThreads(string receiverBroId);
    }
}