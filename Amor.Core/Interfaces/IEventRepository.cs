using Amor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Core.Interfaces
{
    public interface IEventRepository
    {
        Task<int> Add(Event @event);
        Task<int> Update(Event @event);
        Task<bool> Delete(int id);
        Task<Event> Get(int id);
        Task<IList<Event>> GetByName(string name);        
    }
}
