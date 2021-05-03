using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Amor.Application.InputModels
{
    public class EventInputModel
    {
        [JsonIgnore]
        public int personIdCadastro { get; set; }
        public int Id { get; set; }
        public string PageProfileLink { get; set; }        
        public string About { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<string> Photos { get; set; }
        public AddressInputModel Address { get; set; }
    }
}
