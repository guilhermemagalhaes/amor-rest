using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Amor.Application.InputModels
{
    public class OngInputModel
    {
        [JsonIgnore]
        public int personId { get; set; }

        public string Phone { get; set; }
        public string Name { get; set; }
        public string PageProfileLink { get; set; }
        public string Document  { get; set; }
        public string About { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public IList<string> Photos { get; set; }
        public AddressInputModel Address { get; set; }
    }
}
