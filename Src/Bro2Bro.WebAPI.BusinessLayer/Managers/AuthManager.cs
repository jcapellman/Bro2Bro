using System;
using System.Linq;

using Bro2Bro.WebAPI.DataLayer.EFModel;

namespace Bro2Bro.WebAPI.BusinessLayer.Managers {
    public class AuthManager : BaseManager {
        public AuthManager(Guid? userGUID = null) : base(userGUID) { }

        public Guid? AttemptLogin(string username, string password) {
            using (var eFactory = new EntityFactory()) {
                var user = eFactory.Users.FirstOrDefault(a => a.DisplayName == username && a.Password == password && a.Active);

                return user?.GUID;
            }
        }

        public bool CheckUserGUID(Guid userGUID) {
            using (var eFactory = new EntityFactory()) {
                return eFactory.Users.Any(a => a.GUID == userGUID && a.Active);
            }
        }
    }
}