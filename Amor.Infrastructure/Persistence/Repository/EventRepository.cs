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
    public class EventRepository : IEventRepository
    {
        private readonly AmorAppDbContext _dbContext;
        public EventRepository(AmorAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> Add(Event @event)
        {
            var request = await _dbContext.Events.AddAsync(@event);
            await _dbContext.SaveChangesAsync();
            return request.Entity.Id;

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var eventParticipants = _dbContext.EventParticipants.Where(x => x.EventId == id).ToList();

                if (eventParticipants != null)
                    _dbContext.RemoveRange(eventParticipants);

                var eventPhotos = _dbContext.EventPhotos.Where(x => x.EventId == id).ToList();

                if (eventPhotos != null)
                    _dbContext.RemoveRange(eventPhotos);

                var eventAddress = _dbContext.Address.Where(x => x.EventId == id).ToList();

                if (eventAddress != null)
                    _dbContext.RemoveRange(eventAddress);

                _dbContext.Remove(await _dbContext.Events.FindAsync(id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Event> Get(int id)
        {
            return await _dbContext.Events
                .Include(x => x.EventPhotos).ThenInclude(x => x.Photo)
                .Include(x => x.Address)
                .Include(x => x.EventParticipants).ThenInclude(x => x.Person)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Event>> GetByName(string name)
        {
            return await _dbContext.Events.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<int> Update(Event @event)
        {
            var entity = await _dbContext.Events.FindAsync(@event.Id);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}
