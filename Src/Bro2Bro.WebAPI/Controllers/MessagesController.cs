using System.Collections.Generic;

using Bro2Bro.lib.DAL;
using Bro2Bro.lib.Interfaces;
using Bro2Bro.WebAPI.Auth;

using Microsoft.AspNetCore.Mvc;

namespace Bro2Bro.WebAPI.Controllers
{
    public class MessagesController : BaseController
    {
        public MessagesController(IDatabase iDatabase, IRequestContext requestContext) : base(iDatabase, requestContext) { }

        [HttpGet]
        public List<Messages> GetMessages(string senderBroId, string receiverBroId) =>
            Database.GetMessages(senderBroId, receiverBroId);

        [HttpPost]
        public bool SendMessage(string receiverBroId, string content) => Database.SendMessage(string.Empty, receiverBroId, content);
    }
}