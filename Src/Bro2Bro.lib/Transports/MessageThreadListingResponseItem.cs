using System;

namespace Bro2Bro.lib.Transports
{
    public class MessageThreadListingResponseItem
    {
        public string BroId { get; set; }

        public DateTime LastMessage { get; set; }

        public int MessageCount { get; set; }
    }
}