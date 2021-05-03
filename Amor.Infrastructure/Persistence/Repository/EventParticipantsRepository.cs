using Amor.Core.Entities;
using Amor.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Infrastructure.Persistence.Repository
{
    public class EventParticipantsRepository : IEventParticipantsRepository
    {
        private readonly AmorAppDbContext _dbContext;
        public EventParticipantsRepository(AmorAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> Add(EventParticipants eventParticipants)
        {
            var request = await _dbContext.EventParticipants.AddAsync(eventParticipants);
            await _dbContext.SaveChangesAsync();
            return request.Entity.Id;
        }

        public async Task<EventParticipants> GetByEventId(int eventId)
        {
            return await _dbContext.EventParticipants
                .Include(x => x.Event)
                .Where(x => x.EventId == eventId).FirstOrDefaultAsync();
        }

        public async Task<int> Update(EventParticipants eventParticipants)
        {
            var entity = await _dbContext.EventParticipants.Where(x => x.EventId == eventParticipants.EventId).SingleAsync();
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}
