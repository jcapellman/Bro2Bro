using System.Collections.Generic;

namespace Bro2Bro.WebAPI.Controllers {
    public class MessageController : BaseController {
        // GET api/values
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }
    }
}