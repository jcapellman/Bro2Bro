using System;
using System.Web.Http;

namespace Bro2Bro.WebAPI.Controllers {
    public class BaseController : ApiController {
        public Guid? USER_GUID {
            get {
                if (Request.Properties.ContainsKey("UserGUID")) {
                    return Guid.Parse(Request.Properties["UserGUID"].ToString());
                }

                return (Guid?)null;
            }
        }
    }
}