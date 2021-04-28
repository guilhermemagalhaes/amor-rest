﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Amor.Core.Entities
{
    public class EventPhoto : Base
    {
        protected EventPhoto() { }
        public EventPhoto(int eventId, int photoId)
        {
            EventId = eventId;
            PhotoId = photoId;
        }

        public int EventId { get; private set; }
        public Event Event { get; private set; }
        public int PhotoId { get; private set; }
        public Photo Person { get; private set; }
    }
}
