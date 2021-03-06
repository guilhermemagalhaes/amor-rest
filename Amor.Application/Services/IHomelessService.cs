using Amor.Application.InputModels;
using Amor.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public interface IHomelessService
    {
        Task<HomelessViewModel> Get(int id);
        Task<bool> Add(HomelessInputModel homelessInputModel);
        Task<bool> Update(HomelessInputModel homelessInputModel);
    }
}
