using Amor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Core.Interfaces
{
    public interface ISupporterRepository
    {
        Task<int> Add(Supporter supporter);
    }
}
