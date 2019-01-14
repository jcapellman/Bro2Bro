using Bro2Bro.lib.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Bro2Bro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected readonly IDatabase Database;

        public BaseController(IDatabase iDatabase)
        {
            Database = iDatabase;
        }
    }
}