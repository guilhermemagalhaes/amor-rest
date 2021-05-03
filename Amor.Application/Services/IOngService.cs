using Amor.Application.InputModels;
using Amor.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public interface IOngService
    {
        Task<OngViewModel> GetByPersonId(int id);        
        Task<bool> Update(OngInputModel ongInputModel);
        Task<IList<SearchByNameViewModel>> GetByName(string name);
    }
}
