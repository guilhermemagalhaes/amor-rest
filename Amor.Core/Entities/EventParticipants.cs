using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class EventParticipants : Base
    {
        protected EventParticipants() { }
        public EventParticipants(int personId, int eventId, bool organizer)
        {
            PersonId = personId;
            EventId = eventId;
            Organizer = organizer;
        }

        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public int EventId { get; private set; }
        public Event Event { get; private set; }
        public bool Organizer { get; private set; }
    }
}
