using Amor.Application.InputModels;
using Amor.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public interface IEventService
    {
        Task<EventViewModel> Get(int id);
        Task<bool> Add(EventInputModel eventInputModel);
        Task<bool> Update(EventInputModel eventInputModel);
    }
}
