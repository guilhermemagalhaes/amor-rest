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

        public async Task<Event> Get(int id)
        {
            return await _dbContext.Events
                .Include(x => x.EventPhotos).ThenInclude(x => x.Photo)
                .Include(x => x.Address)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Update(Event @event)
        {
            var entity = await _dbContext.Events.FindAsync(@event.Id);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}
