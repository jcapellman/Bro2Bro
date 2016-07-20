using System;
using System.Threading.Tasks;

namespace Bro2Bro.PCL.Handlers {
    public class AuthHandler : BaseHandler {
        protected override string BaseControllerName() => "Auth";

        public async Task<Guid?> CheckAuth(string username, string password) => await GetAsync<Guid?>($"username={username}&password={password}");
    }
}