﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class Ong : Base
    {
        protected Ong() { }
        public Ong(DateTime? openingTime, DateTime? closingTime, string pageProfileLink, string about, Person person)
        {
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            PageProfileLink = pageProfileLink;
            About = about;
            Person = person;
        }

        public Ong(DateTime? openingTime, DateTime? closingTime, string pageProfileLink, string about, int personId)
        {
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            PageProfileLink = pageProfileLink;
            About = about;
            PersonId = personId;            
        }

        public void Update(DateTime? openingTime, DateTime? closingTime, string pageProfileLink, string about)
        {
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            PageProfileLink = pageProfileLink;
            About = about;            
        }

        public DateTime? OpeningTime { get; private set; }
        public DateTime? ClosingTime { get; private set; }
        public string PageProfileLink { get; private set; }
        public string About { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public ICollection<Supporter> Supporters { get; private set; }
    }
}
