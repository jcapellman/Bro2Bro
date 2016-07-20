using System;

using Bro2Bro.WebAPI.BusinessLayer.Managers;

namespace Bro2Bro.WebAPI.Controllers {
    public class AuthController : BaseController {
        public Guid? GET(string username, string password) => new AuthManager().AttemptLogin(username, password);
    }
}