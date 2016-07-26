using System.Runtime.Serialization;

namespace Bro2Bro.Mobile.Objects {
    [DataContract]
    public class LoginItem {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}