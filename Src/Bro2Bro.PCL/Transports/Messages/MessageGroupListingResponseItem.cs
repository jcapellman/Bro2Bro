using System;
using System.Runtime.Serialization;

namespace Bro2Bro.PCL.Transports.Messages {
    [DataContract]
    public class MessageGroupListingResponseItem {
        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public DateTime PostTime { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}