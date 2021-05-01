using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Amor.Application.InputModels
{
    public class AddressInputModel
    {
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Neighborhood { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        [JsonPropertyName("Address")]
        public string AddressDesc { get; set; }
    }
}
