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

    public class HomelessRepository : IHomelessRepository
    {
        private readonly AmorAppDbContext _dbContext;
        public HomelessRepository(AmorAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> Add(Homeless homeless)
        {
            try
            {
                var request = await _dbContext.Homeless.AddAsync(homeless);
                await _dbContext.SaveChangesAsync();
                return request.Entity.Id;
            }
            catch(Exception e)
            {
                throw;
            }            
        }

        public async Task<Homeless> Get(int id)
        {
            return await _dbContext.Homeless
                .Include(x => x.Person).ThenInclude(x => x.Address)
                .Include(x => x.Person).ThenInclude(x => x.PersonPhotos).ThenInclude(x => x.Photo)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Update(Homeless homeless)
        {
            var entity = await _dbContext.Homeless.FindAsync(homeless.Id);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
    
}
