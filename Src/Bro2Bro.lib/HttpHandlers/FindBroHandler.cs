using System.Collections.Generic;
using System.Threading.Tasks;

using Bro2Bro.lib.DAL;
using Bro2Bro.lib.HttpHandlers.Base;

namespace Bro2Bro.lib.HttpHandlers
{
    public class FindBroHandler : BaseHttpHandler {
        public FindBroHandler(string baseWebServiceUrlConnection, string broId) : base(baseWebServiceUrlConnection, broId)
        {
        }

        public async Task<List<Bros>> FindBrosAsync(string query) => await GetAsync<List<Bros>>("FindBro", query);
    }
}