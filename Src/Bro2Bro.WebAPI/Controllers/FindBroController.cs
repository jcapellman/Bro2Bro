using System.Collections.Generic;

using Bro2Bro.lib.DAL;
using Bro2Bro.lib.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Bro2Bro.WebAPI.Controllers
{
    
    public class FindBroController : BaseController
    {
        public FindBroController(IDatabase iDatabase) : base(iDatabase) { }
        
        [HttpGet]
        public List<Bros> List(string broName) => Database.GetBros(broName);
    }
}