using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Amor.Application.ViewModels
{
    public class AddressViewModel
    {
        public AddressViewModel(decimal Longitude, decimal Latitude, string Neighborhood, string Zip, string City, string Province, string AddressDesc)
        {
            this.Longitude = Longitude;
            this.Latitude = Longitude;
            this.Neighborhood = Neighborhood;
            this.Zip = Zip;
            this.City = City;
            this.Province = Province;
            this.AddressDesc = AddressDesc;
        }

        public decimal Longitude { get; private set; }
        public decimal Latitude { get; private set; }
        public string Neighborhood { get; private set; }
        public string Zip { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }

        [JsonPropertyName("Address")]
        public string AddressDesc { get; private set; }
    }
}
