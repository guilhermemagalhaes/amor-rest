using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class Address : Base
    {
        protected Address() { }
        
        public Address(decimal longitude, decimal latitude, string addressDesc, string neighborhood, string province, string zip, string city, int? personId, int? eventId)
        {
            Longitude = longitude;
            Latitude = latitude;
            AddressDesc = addressDesc;
            Neighborhood = neighborhood;
            Province = province;
            Zip = zip;
            City = city;
            PersonId = personId;
            EventId = eventId;
        }


        public decimal Longitude { get; private set; }
        public decimal Latitude { get; private set; }
        public string AddressDesc { get; private set; }
        public string Neighborhood { get; private set; }
        public string Province { get; private set; }
        public string Zip { get; private set; }
        public string City { get; private set; }
        public int? PersonId { get; private set; }
        public Person Person { get; private set; }
        public int? EventId { get; private set; }
        public Event Event { get; private set; }
    }
}
