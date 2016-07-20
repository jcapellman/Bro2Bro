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
    }
}