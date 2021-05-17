using Amor.Application.InputModels;
using Amor.Application.ViewModels;
using Amor.Core.Entities;
using Amor.Core.Interfaces;
using AutoMapper;
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
        private readonly IEventParticipantsRepository _eventParticipantsRepository;
        private readonly IHomelessRepository _homelessRepository;
        private readonly IMapper _mapper;
        private readonly IOngRepository _ongRepository;
        public CoreService(ICoreRepository coreRepository,
                           IEventRepository eventRepository,
                           IMapper mapper,
                           IEventParticipantsRepository eventParticipantsRepository,
                           IHomelessRepository homelessRepository,
                           IOngRepository ongRepository)
        {
            _coreRepository = coreRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
            _eventParticipantsRepository = eventParticipantsRepository;
            _homelessRepository = homelessRepository;
            _ongRepository = ongRepository;
        }

        public async Task<List<SearchOnMyLocationViewModel>> GetSearchOnMyLocations(List<SearchOnMyLocationInputModel> models, int personId)
        {
            string polygon = string.Empty;
            List<SearchOnMyLocationViewModel> ret = new List<SearchOnMyLocationViewModel>();

            polygon = "POLYGON((";
            foreach (var i in models)
            {
                polygon += i.@long.ToString().Replace(",", ".") + " " + i.lat.ToString().Replace(",", ".") + ",";
            }
            polygon += models[0].@long.ToString().Replace(",", ".") + " " + models[0].lat.ToString().Replace(",", ".");
            polygon += "))";

            var listaIntersect = await _coreRepository.GetSearchOnMyLocations(polygon);

            if (listaIntersect != null)
            {
                #region Events
                
                var events = listaIntersect.Where(x => x.EventId != null).ToList();

                if (events != null)
                {
                    foreach (var i in events)
                    {
                        var eventAtual = await _eventRepository.Get((int)i.EventId);
                        var eventParticipant = await _eventParticipantsRepository.GetOrganizerByEventId(eventAtual.Id);

                        var temp = new SearchOnMyLocationViewModel()
                        {
                            Id = eventAtual.Id,
                            Type = "EVENT",
                            Name = eventAtual.Name,
                            About = eventAtual.About,
                            OpeningTime = eventAtual.StartDate.ToString(),
                            ClosingTime = eventAtual.EndDate.ToString(),
                            Edited = eventParticipant.PersonId == personId
                        };

                        if (eventAtual.Address.Count() > 0)
                        {
                            var address = _mapper.Map<Address, AddressViewModel>(eventAtual.Address.FirstOrDefault());
                            temp.Address = address;
                        }

                        temp.Photos = new List<string>();
                        if (eventAtual.EventPhotos.Count() > 0)
                        {
                            foreach (var item in eventAtual.EventPhotos)
                            {
                                temp.Photos.Add(item.Photo.URL);
                            }
                        }
                        ret.Add(temp);
                    }
                }
                #endregion

                #region Homeless
                var homeless = listaIntersect.Where(x => x.HomelessId != null).ToList();

                if(homeless != null)
                {
                    foreach(var i in homeless)
                    {
                        var homelessAtual = await _homelessRepository.Get((int)i.HomelessId);

                        var temp = new SearchOnMyLocationViewModel()
                        {
                            Id = homelessAtual.Id,
                            Type = "HOMELESS",
                            Name = homelessAtual.Person.Name,
                            About = homelessAtual.About,
                            Needs = homelessAtual.Needs,
                        };

                        if(homelessAtual.Person.Address.Count() > 0)
                        {
                            var address = _mapper.Map<Address, AddressViewModel>(homelessAtual.Person.Address.FirstOrDefault());
                            temp.Address = address;
                        }
                        ret.Add(temp);
                    }
                }
                #endregion

                #region Ong
                var ong = listaIntersect.Where(x => x.OngId != null).ToList();

                if(ong != null)
                {
                    foreach(var i in ong)
                    {
                        var ongAtual = await _ongRepository.Get((int)i.OngId);

                        var temp = new SearchOnMyLocationViewModel()
                        {
                            Id = ongAtual.Id,
                            Type = "ONG",
                            Name = ongAtual.Person.Name,
                            About = ongAtual.About,
                            OpeningTime = ongAtual.OpeningTime,
                            ClosingTime = ongAtual.ClosingTime,
                            
                        };

                        temp.Photos = new List<string>();                        
                        if (ongAtual.Person.PersonPhotos.Count() > 0)
                        {
                            foreach (var item in ongAtual.Person.PersonPhotos)
                            {
                                temp.Photos.Add(item.Photo.URL);
                            }
                        }

                        temp.Supporters = new List<string>();    
                        if(ongAtual.Supporters?.Count() > 0)
                        {
                            foreach (var item in ongAtual.Supporters)
                            {
                                if (!item.Donation.AnonymousDonation)
                                    temp.Supporters.Add(item.Donation.Person.Name);
                            }
                        }

                        ret.Add(temp);
                    }
                }
                #endregion
            }
            return ret;
        }
    }
}
