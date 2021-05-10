using Amor.Core.Entities;
using Amor.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Infrastructure.Persistence.Repository
{
    public class CoreRepository : ICoreRepository
    {
        private readonly AmorAppDbContext _dbContext;
        public CoreRepository(AmorAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SearchOnMyLocation>> GetSearchOnMyLocations(string polygon)
        {
            return await _dbContext.SearchOnMyLocation.FromSqlRaw(@$"EXECUTE [dbo].[GETSTIntersectsAddress] @POLYGON = '{polygon}'").ToListAsync();
        }
    }
}
