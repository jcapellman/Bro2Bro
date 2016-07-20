using System;

namespace Bro2Bro.WebAPI.BusinessLayer.Managers {
    public class BaseManager {
        internal Guid? _userGUID;

        public BaseManager(Guid? userGUID) {
            _userGUID = userGUID;
        }
    }
}