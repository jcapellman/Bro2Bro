using System;
using System.Runtime.Serialization;

namespace Bro2Bro.PCL.Transports.Messages {
    [DataContract]
    public class MessageRequestItem {
        [DataMember]
        public Guid ReceiverGUID { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}