using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Amor.Application.InputModels
{
    public class EventParticipantsInputModel
    {
        [JsonIgnore]
        public int PersonId { get; set; }
        public int EventId { get; set; }        
    }
}
