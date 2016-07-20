using System;
using System.ComponentModel.DataAnnotations;

namespace Bro2Bro.WebAPI.DataLayer.EFModel.EFObjects {
    public class Messages {
        [Key]
        public Guid GUID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public Guid SenderGUID { get; set; }

        public Guid ReceiverGUID { get; set; }

        public string Message { get; set; }
    }
}