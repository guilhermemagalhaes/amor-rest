using Amor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<int> Add(Address address);
        Task<int> Update(Address address);
        Task<Address> GetByPersonId(int personId);
        Task<Address> GetByEventId(int eventId);
    }
}
