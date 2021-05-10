using Amor.Application.InputModels;
using Amor.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public interface ICoreService
    {
        Task<List<SearchOnMyLocationViewModel>> GetSearchOnMyLocations(List<SearchOnMyLocationInputModel> models);
    }
}
