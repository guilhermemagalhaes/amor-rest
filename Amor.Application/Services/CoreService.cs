using Amor.Application.InputModels;
using Amor.Application.ViewModels;
using Amor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public class CoreService : ICoreService
    {
        private readonly ICoreRepository _coreRepository;
        private readonly IEventRepository _eventRepository;
        public CoreService(ICoreRepository coreRepository, IEventRepository eventRepository)
        {
            _coreRepository = coreRepository;
            _eventRepository = eventRepository;
        }

        public async Task<List<SearchOnMyLocationViewModel>> GetSearchOnMyLocations(List<SearchOnMyLocationInputModel> models)
        {
            string polygon = string.Empty;
            List<SearchOnMyLocationViewModel> ret = null;

            polygon = "POLYGON((";
            foreach (var i in models)
            {
                polygon += i.lat.ToString().Replace(",", ".") + " " + i.@long.ToString().Replace(",", ".") + ",";
            }
            polygon += models[0].lat.ToString().Replace(",", ".") + " " + models[0].@long.ToString().Replace(",", ".");
            polygon += "))";

            var listaIntersect = await _coreRepository.GetSearchOnMyLocations(polygon);

            if (listaIntersect != null)
            {
                var events = listaIntersect.Where(x => x.EventId != null).ToList();

                if (events != null)
                {
                    foreach (var i in events)
                    {
                        var eventAtual = await _eventRepository.Get((int)i.EventId);

                        ret.Add(new SearchOnMyLocationViewModel()
                        {
                            Id = eventAtual.Id,
                            Type = "EVENT"
                        });
                    }
                }
            }
            return ret;
        }
    }
}
