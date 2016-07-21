using Bro2Bro.PCL.Transports.Messages;
using Bro2Bro.WebAPI.DataLayer.EFModel;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Bro2Bro.WebAPI.BusinessLayer.Managers {
    public class MessageManager : BaseManager {
        public MessageManager(Guid? userGUID) : base(userGUID) { }

        public List<MessageGroupListingResponseItem> GetListing() {
            using (var eFactory = new EntityFactory()) {
                return eFactory.Database.SqlQuery<MessageGroupListingResponseItem>("WEBAPI_getMessageListSP @UserGUID", new SqlParameter("@UserGUID", _userGUID.Value)).ToList();
            }
        }

        public bool PostMessage(MessageRequestItem requestItem) {
            using (var eFactory = new EntityFactory()) {
                var message = eFactory.Messages.Create();

                message.Active = true;
                message.Created = DateTimeOffset.Now;
                message.Modified = DateTimeOffset.Now;
                message.ReceiverGUID = requestItem.ReceiverGUID;
                message.SenderGUID = _userGUID.Value;
                message.GUID = Guid.NewGuid();

                eFactory.Messages.Add(message);
                eFactory.SaveChanges();

                return true;
            }
        }
    }
}