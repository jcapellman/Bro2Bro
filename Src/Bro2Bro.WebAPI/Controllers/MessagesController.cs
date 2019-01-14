using System.Collections.Generic;

using Bro2Bro.lib.DAL;
using Bro2Bro.lib.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Bro2Bro.WebAPI.Controllers
{
    public class MessagesController : BaseController
    {
        public MessagesController(IDatabase iDatabase) : base(iDatabase)
        {
        }

        [HttpGet]
        public List<Messages> GetMessages(string senderBroId, string receiverBroId) =>
            Database.GetMessages(senderBroId, receiverBroId);
    }
}