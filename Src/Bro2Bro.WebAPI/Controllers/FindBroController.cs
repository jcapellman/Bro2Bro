using System.Collections.Generic;

using Bro2Bro.lib.DAL;
using Bro2Bro.lib.Interfaces;
using Bro2Bro.WebAPI.Auth;

using Microsoft.AspNetCore.Mvc;

namespace Bro2Bro.WebAPI.Controllers
{
    
    public class FindBroController : BaseController
    {
        public FindBroController(IDatabase iDatabase, IHttpRequestContext httpRequestContext) : base(iDatabase, httpRequestContext) { }

        [HttpGet]
        public List<Bros> List(string query) => Database.GetBros(query);
    }
}