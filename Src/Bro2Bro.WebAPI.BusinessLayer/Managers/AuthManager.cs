using System;
using System.Linq;

using Bro2Bro.WebAPI.DataLayer.EFModel;

namespace Bro2Bro.WebAPI.BusinessLayer.Managers {
    public class AuthManager : BaseManager {
        public Guid? AttemptLogin(string username, string password) {
            using (var eFactory = new EFModel()) {
                var user = eFactory.Users.FirstOrDefault(a => a.DisplayName == username && a.Password == password && a.Active);

                return user?.GUID;
            }
        }
    }
}