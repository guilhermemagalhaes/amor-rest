using Amor.Core.Entities;
using Amor.Core.Enums;
using Amor.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> UpdatePerson(Person person)
        {
            var entity = await _dbContext.Person.FindAsync(person.Id);
            entity = new Person(person.Name, person.Phone);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Person> GetPerson(int id)
        {
            return await _dbContext.Person.FindAsync(id);
        }

        public async Task<string> DocumentExists(string document)
        {
            string ret = string.Empty;

            bool isOng = document.Length > 11;
            var profile = isOng ? UserProfileEnum.ONG : UserProfileEnum.VOLUNTARY;

            if (profile == UserProfileEnum.ONG)
                return await _dbContext.Person.AnyAsync(x => x.LegalPerson.CNPJ == document) ? ret = "CNPJ already registered" : ret = string.Empty;
            else if(profile == UserProfileEnum.VOLUNTARY)
                return await _dbContext.Person.AnyAsync(x => x.PhysicalPerson.CPF == document) ? ret = "CPF already registered" : ret = string.Empty;

            return ret;            
        }
    }
}
