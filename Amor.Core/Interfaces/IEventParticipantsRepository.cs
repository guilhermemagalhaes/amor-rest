using Amor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Core.Interfaces
{
    public interface IEventParticipantsRepository
    {
        Task<int> Add(EventParticipants eventParticipants);
        Task<int> Update(EventParticipants eventParticipants);
        Task<EventParticipants> GetByEventId(int eventId);
    }
}
