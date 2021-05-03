using Amor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Core.Interfaces
{
    public interface IOngRepository
    {
        Task<int> Add(Ong ong);
        Task<int> Update(Ong ong);
        Task<Ong> Get(int id);
        Task<Ong> GetByPersonId(int personId);
    }
}
