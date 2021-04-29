using Amor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<int> UpdatePerson(Person person);
        Task<int> AddPerson(Person person);
        Task<int> AddLegalPerson(LegalPerson legalPerson);
        Task<int> AddPhysicalPerson(PhysicalPerson physicalPerson);
        Task<Person> GetPerson(int id);
    }
}
