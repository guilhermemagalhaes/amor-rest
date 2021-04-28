using Amor.Core.Entities;
using Amor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AmorAppDbContext _dbContext;
        public UserRepository(AmorAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> Add(User user)
        {
            var request = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return request.Entity.Id;            
        }
    }
}
