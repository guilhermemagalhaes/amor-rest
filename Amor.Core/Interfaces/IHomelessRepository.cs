using Amor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Core.Interfaces
{
    public interface IHomelessRepository
    {
        Task<int> Add(Homeless homeless);
        Task<int> Update(Homeless homeless);
        Task<Homeless> Get(int id);
    }
}
