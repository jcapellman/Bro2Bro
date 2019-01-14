using Bro2Bro.lib.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Bro2Bro.WebAPI.Controllers
{
    public class RegisterController : BaseController
    {
        public RegisterController(IDatabase iDatabase) : base(iDatabase) { }

        [HttpPost]
        public bool Register(string broId, string displayName) => Database.RegisterBro(broId, displayName);
    }
}