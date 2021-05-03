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
    public class OngRepository : IOngRepository
    {
        private readonly AmorAppDbContext _dbContext;
        public OngRepository(AmorAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> Add(Ong ong)
        {
            var request = await _dbContext.Ongs.AddAsync(ong);
            await _dbContext.SaveChangesAsync();
            return request.Entity.Id;

        }

        public async Task<Ong> Get(int id)
        {
            return await _dbContext.Ongs
                .Include(x => x.Person).ThenInclude(x => x.Address)
                .Include(x => x.Person).ThenInclude(x => x.PersonPhotos).ThenInclude(x => x.Photo)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Ong>> GetByName(string name)
        {
            return await _dbContext.Ongs
                .Include(x => x.Person)
                .Where(x => x.Person.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<Ong> GetByPersonId(int personId)
        {
            return await _dbContext.Ongs
               .Include(x => x.Person).ThenInclude(x => x.Address)
               .Include(x => x.Person).ThenInclude(x => x.LegalPerson)
               .Include(x => x.Person).ThenInclude(x => x.PersonPhotos).ThenInclude(x => x.Photo)
               .Where(x => x.PersonId == personId)
               .FirstOrDefaultAsync();
        }

        public async Task<int> Update(Ong ong)
        {
            var entity = await _dbContext.Ongs.FindAsync(ong.Id);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}

