using Bro2Bro.lib.Interfaces;
using Bro2Bro.WebAPI.Auth;

using Microsoft.AspNetCore.Mvc;

namespace Bro2Bro.WebAPI.Controllers
{
    public class RegisterController : BaseController
    {
        public RegisterController(IDatabase iDatabase, IHttpRequestContext httpRequestContext) : base(iDatabase, httpRequestContext) { }

        [HttpPost]
        public bool Register(string broId, string displayName) => Database.RegisterBro(broId, displayName);
    }
}