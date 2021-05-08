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

    public class DonationRepository : IDonationRepository
    {
        private readonly AmorAppDbContext _dbContext;
        public DonationRepository(AmorAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> Add(Donation donation)
        {
            var request = await _dbContext.Donations.AddAsync(donation);
            await _dbContext.SaveChangesAsync();
            return request.Entity.Id;
        }     
    }
    
}
