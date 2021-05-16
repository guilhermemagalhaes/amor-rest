using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class Ong : Base
    {
        protected Ong() { }
        public Ong(string openingTime, string closingTime, string pageProfileLink, string about, Person person)
        {
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            PageProfileLink = pageProfileLink;
            About = about;
            Person = person;
        }

        public Ong(string openingTime, string closingTime, string pageProfileLink, string about, int personId)
        {
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            PageProfileLink = pageProfileLink;
            About = about;
            PersonId = personId;            
        }

        public void Update(string openingTime, string closingTime, string pageProfileLink, string about)
        {
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            PageProfileLink = pageProfileLink;
            About = about;            
        }

        public string OpeningTime { get; private set; }
        public string ClosingTime { get; private set; }
        public string PageProfileLink { get; private set; }
        public string About { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public ICollection<Supporter> Supporters { get; private set; }
    }
}
