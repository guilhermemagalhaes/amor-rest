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

        public async Task<User> GetUser(int id)
        {
            return await _dbContext.Users
                .Where(x => x.Id == id)
                .Include(x => x.Person).ThenInclude(x => x.Address).AsNoTracking()
                .Include(x => x.Person).ThenInclude(x => x.LegalPerson).AsNoTracking()
                .Include(x => x.Person).ThenInclude(x => x.PhysicalPerson).AsNoTracking()
                .FirstOrDefaultAsync();
        }
        public async Task<User> GetUserByPersonId(int personId)
        {
            return await _dbContext.Users
                .Where(x => x.PersonId == personId)
                .Include(x => x.Person).ThenInclude(x => x.Address).AsNoTracking()
                .Include(x => x.Person).ThenInclude(x => x.LegalPerson).AsNoTracking()
                .Include(x => x.Person).ThenInclude(x => x.PhysicalPerson).AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<User> SignIn(string email, string password)
        {
            return await _dbContext.Users
                .Where(x => x.Email == email && x.Password == password)
                .Include(x => x.Person).ThenInclude(x => x.Address).AsNoTracking()
                .Include(x => x.Person).ThenInclude(x => x.LegalPerson).AsNoTracking()
                .Include(x => x.Person).ThenInclude(x => x.PhysicalPerson).AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _dbContext.Users.AnyAsync(x => x.Email == email);
        }
    }
}
