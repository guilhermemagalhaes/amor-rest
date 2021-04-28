using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class AddressViewModel
    {
        public AddressViewModel(decimal Longitude, decimal Latitude, string Neighborhood, string Zip, string City)
        {
            this.Longitude = Longitude;
            this.Latitude = Longitude;
            this.Neighborhood = Neighborhood;
            this.Zip = Zip;
            this.City = City;
        }

        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Neighborhood { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
    }
}
