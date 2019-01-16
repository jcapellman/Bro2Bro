using Bro2Bro.lib.Interfaces;
using Bro2Bro.WebAPI.Auth;

using Microsoft.AspNetCore.Mvc;

namespace Bro2Bro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected readonly IDatabase Database;

        protected IHttpRequestContext HttpRequestContext;

        public BaseController(IDatabase iDatabase, IHttpRequestContext httpRequestContext)
        {
            Database = iDatabase;
            HttpRequestContext = httpRequestContext;
        }
    }
}