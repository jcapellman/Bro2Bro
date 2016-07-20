using System;
using System.ComponentModel.DataAnnotations;

namespace Bro2Bro.WebAPI.DataLayer.EFModel.EFObjects {
    public class Users {
        [Key]
        public Guid GUID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public string DisplayName { get; set; }

        public string Password { get; set; }
    }
}