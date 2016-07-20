using Bro2Bro.PCL.Transports.Messages;
using Bro2Bro.WebAPI.BusinessLayer.Managers;

using System.Collections.Generic;

namespace Bro2Bro.WebAPI.Controllers {
    public class MessageController : BaseController {
        public List<MessageGroupListingResponseItem> Get() => new MessageManager(USER_GUID).GetListing();
    }
}