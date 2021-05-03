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
    public class AddressRepository : IAddressRepository
    {
        private readonly AmorAppDbContext _dbContext;
        public AddressRepository(AmorAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> Add(Address address)
        {
            var request = await _dbContext.Address.AddAsync(address);
            await _dbContext.SaveChangesAsync();
            return request.Entity.Id;

        }

        public async Task<Address> GetByEventId(int eventId)
        {
            return await _dbContext.Address
                .Include(x => x.Person).ThenInclude(x => x.Address)
                .Include(x => x.Person).ThenInclude(x => x.PersonPhotos).ThenInclude(x => x.Photo)
                .Where(x => x.EventId == eventId)
                .FirstOrDefaultAsync();
        }

        public async Task<Address> GetByPersonId(int personId)
        {
            return await _dbContext.Address
                .Include(x => x.Person).ThenInclude(x => x.Address)
                .Include(x => x.Person).ThenInclude(x => x.PersonPhotos).ThenInclude(x => x.Photo)
                .Where(x => x.PersonId == personId)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Update(Address address)
        {
            try
            {
                var entity = await _dbContext.Address.FindAsync(address.Id);
                await _dbContext.SaveChangesAsync();
                return entity.Id;
            }
            catch(Exception e)
            {
                throw;
            }            
        }
    }
}
