using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class Event : Base
    {
        protected Event() { }

        public Event(DateTime startDate, DateTime endDate, string pageProfileLink, string about)
        {
            StartDate = startDate;
            EndDate = endDate;
            PageProfileLink = pageProfileLink;
            About = about;
        }

        public Event(DateTime startDate, DateTime endDate, string pageProfileLink, string about, ICollection<EventPhoto> eventPhotos, ICollection<EventParticipants> eventParticipants)
        {
            StartDate = startDate;
            EndDate = endDate;
            PageProfileLink = pageProfileLink;
            About = about;
            EventPhotos = eventPhotos;
            EventParticipants = eventParticipants;
        }

        public void Update(DateTime startDate, DateTime endDate, string pageProfileLink, string about)
        {
            StartDate = startDate;
            EndDate = endDate;
            PageProfileLink = pageProfileLink;
            About = about;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string PageProfileLink { get; private set; }
        public string About { get; private set; }
        public virtual ICollection<Address> Address { get; set; }
        public ICollection<EventParticipants> EventParticipants { get; set; }
        public ICollection<EventPhoto> EventPhotos { get; set; }
    }
}
