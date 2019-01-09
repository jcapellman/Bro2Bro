using System;

namespace Bro2Bro.Mobile.Models
{
    public class Item
    {
        public string Id { get; set; }

        public string BroName { get; set; }

        public DateTime Created { get; set; }

        public string CreatedPrettyDisplay => Created.Date == DateTime.Now.Date ? $"{Created:h:mm tt}" : $"{Created:M:d}";

        public string Content { get; set; }
    }
}