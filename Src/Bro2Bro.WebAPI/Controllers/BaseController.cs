using System;
using System.Web.Http;

namespace Bro2Bro.WebAPI.Controllers {
    public class BaseController : ApiController {
        private Guid? _userGUID;

        public Guid? USER_GUID {
            get { return _userGUID ?? (_userGUID = Request.Properties.ContainsKey("UserGUID") ? Guid.Parse(Request.Properties["UserGUID"].ToString()) : (Guid?)null); }
        }
    }
}