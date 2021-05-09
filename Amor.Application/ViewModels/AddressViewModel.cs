using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Amor.Application.ViewModels
{
    public class AddressViewModel
    {
        protected AddressViewModel() { }
        public AddressViewModel(decimal longitude, decimal latitude, string zip, string neighborhood, string city, string province, string number, string street, string country)
        {
            Longitude = longitude;
            Latitude = latitude;
            Zip = zip;
            Neighborhood = neighborhood;
            City = city;
            Province = province;
            Number = number;
            Street = street;
            Country = country;
        }

        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Zip { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
    }
}
