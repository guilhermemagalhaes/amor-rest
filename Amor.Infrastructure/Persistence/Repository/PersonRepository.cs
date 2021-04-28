using Amor.Core.Entities;
using Amor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Infrastructure.Persistence.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AmorAppDbContext _dbContext;
        public PersonRepository(AmorAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> AddPerson(Person person)
        {
            var request = await _dbContext.Person.AddAsync(person);
            await _dbContext.SaveChangesAsync();
            return request.Entity.Id;            
        }

        public async Task<int> AddLegalPerson(LegalPerson legalPerson)
        {
            var request = await _dbContext.LegalPerson.AddAsync(legalPerson);
            await _dbContext.SaveChangesAsync();
            return request.Entity.PersonId;
        }

        public async Task<int> AddPhysicalPerson(PhysicalPerson physicalPerson)
        {
            var request = await _dbContext.PhysicalPerson.AddAsync(physicalPerson);
            await _dbContext.SaveChangesAsync();
            return request.Entity.PersonId;
        }
    }
}
