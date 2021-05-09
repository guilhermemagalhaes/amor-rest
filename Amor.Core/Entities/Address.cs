using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class Address : Base
    {
        protected Address() { }
        
        public Address(decimal longitude, decimal latitude, string street, string neighborhood, string province, string zip, string city, string country, string number, int? personId, int? eventId)
        {
            Longitude = longitude;
            Latitude = latitude;
            Street = street;
            Neighborhood = neighborhood;
            Province = province;
            Zip = zip;
            City = city;
            Country = country;
            Number = number;
            PersonId = personId;
            EventId = eventId;
        }

        public void Update(decimal longitude, decimal latitude, string street, string neighborhood, string province, string zip, string city, string country, string number, int? personId, int? eventId)
        {
            Longitude = longitude;
            Latitude = latitude;
            Street = street;
            Neighborhood = neighborhood;
            Province = province;
            Zip = zip;
            City = city;
            PersonId = personId;
            EventId = eventId;
            Country = country;
            Number = number;
        }

        public decimal Longitude { get; private set; }
        public decimal Latitude { get; private set; }
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public string Province { get; private set; }
        public string Zip { get; private set; }
        public string City { get; private set; }
        public int? PersonId { get; private set; }
        public Person Person { get; private set; }
        public int? EventId { get; private set; }
        public Event Event { get; private set; }
        public string Number { get; private set; }
        public string Country { get; private set; }
    }
}
