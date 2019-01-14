using System;

using Bro2Bro.lib.DAL.Base;

namespace Bro2Bro.lib.DAL
{
    public class Messages : BaseTable
    {
        public string ReceiverBroId { get; set; }

        public string SenderBroId { get; set; }

        public DateTime Timestamp { get; set; }

        public string Content { get; set; }
    }
}