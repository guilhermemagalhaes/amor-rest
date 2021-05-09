using Amor.Application.InputModels;
using Amor.Application.ViewModels;
using Amor.Core.Entities;
using Amor.Core.Enums;
using Amor.Core.Interfaces;
using AutoMapper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IHomelessRepository _homelessRepository;
        private readonly IEventParticipantsRepository _eventParticipantsRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public EventService(IHomelessRepository homelessRepository,
                            IEventParticipantsRepository eventParticipantsRepository,
                            IEventRepository eventRepository,
                            IPersonRepository personRepository,
                            IPhotoRepository photoRepository,
                            IAddressRepository addressRepository,
                            IMapper mapper)
        {
            _homelessRepository = homelessRepository;
            _eventParticipantsRepository = eventParticipantsRepository;
            _eventRepository = eventRepository;
            _personRepository = personRepository;
            _photoRepository = photoRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(EventInputModel eventInputModel)
        {
            List<EventPhoto> eventPhotos = new List<EventPhoto>();
            foreach (var i in eventInputModel.Photos)
                eventPhotos.Add(new EventPhoto(new Photo(i)));

            List<EventParticipants> eventParticipants = new List<EventParticipants>();
            eventParticipants.Add(new EventParticipants(eventInputModel.personIdCadastro, true));

            var eventId = await _eventRepository.Add(new Event(eventInputModel.Name, eventInputModel.StartDate, eventInputModel.EndDate, eventInputModel.PageProfileLink, eventInputModel.About, eventPhotos, eventParticipants));

            await _addressRepository.Add(new Address(eventInputModel.Address.Longitude,
                                              eventInputModel.Address.Longitude,
                                              eventInputModel.Address.Street,
                                              eventInputModel.Address.Neighborhood,
                                              eventInputModel.Address.Province,
                                              eventInputModel.Address.Zip,
                                              eventInputModel.Address.City,
                                              eventInputModel.Address.Country,
                                              eventInputModel.Address.Number,
                                              personId: null,
                                              eventId: eventId));

            return eventId > 0;
        }

        public async Task<bool> AddEventParticipants(EventParticipantsInputModel eventParticipantsInputModel)
        {
            return await _eventParticipantsRepository.Add(new EventParticipants(eventParticipantsInputModel.PersonId, eventParticipantsInputModel.EventId, false)) > 0;
        }

        public async Task<EventViewModel> Get(int id)
        {
            var response = await _eventRepository.Get(id);

            if (response == null)
                return null;

            var ret = _mapper.Map<Event, EventViewModel>(response);

            ret.Photos = new List<string>();
            foreach (var item in response.EventPhotos)
            {
                ret.Photos.Add(item.Photo.URL);
            }

            if (response.Address.Count() > 0)
            {
                var address = _mapper.Map<Address, AddressViewModel>(response.Address.FirstOrDefault());
                ret.EventAddress = address;
            }

            ret.StartDate = response.StartDate.ToString("dd/MM/yyyy");
            ret.EndDate = response.EndDate.ToString("dd/MM/yyyy");

            return ret;
        }

        public async Task<IList<SearchByNameViewModel>> GetByName(string name)
        {
            IList<SearchByNameViewModel> searchByNames = new List<SearchByNameViewModel>();

            var events = await _eventRepository.GetByName(name);

            foreach (var i in events)
                searchByNames.Add(new SearchByNameViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = "EVENT"
                });
            return searchByNames;
        }

        public async Task<bool> Update(EventInputModel eventInputModel)
        {
            List<EventPhoto> eventPhotos = new List<EventPhoto>();
            foreach (var i in eventInputModel.Photos)
                eventPhotos.Add(new EventPhoto(new Photo(i)));

            var @event = await _eventRepository.Get(eventInputModel.Id);

            @event.Update(eventInputModel.Name, eventInputModel.StartDate, eventInputModel.EndDate, eventInputModel.PageProfileLink, eventInputModel.About);
            @event.EventPhotos = eventPhotos;

            var eventId = await _eventRepository.Update(@event);

            var address = await _addressRepository.GetByEventId(eventId);

            if (address != null)
            {
                address.Update(eventInputModel.Address.Longitude,
                                              eventInputModel.Address.Longitude,
                                              eventInputModel.Address.Street,
                                              eventInputModel.Address.Neighborhood,
                                              eventInputModel.Address.Province,
                                              eventInputModel.Address.Zip,
                                              eventInputModel.Address.City,
                                              eventInputModel.Address.Country,
                                              eventInputModel.Address.Number,
                                               eventId: eventId,
                                               personId: null);

                await _addressRepository.Update(address);
            }
            else
            {
                await _addressRepository.Add(new Address(eventInputModel.Address.Longitude,
                                              eventInputModel.Address.Longitude,
                                              eventInputModel.Address.Street,
                                              eventInputModel.Address.Neighborhood,
                                              eventInputModel.Address.Province,
                                              eventInputModel.Address.Zip,
                                              eventInputModel.Address.City,
                                              eventInputModel.Address.Country,
                                              eventInputModel.Address.Number,
                                               personId: null,
                                               eventId: eventId));
            }

            return eventId > 0;
        }
    }
}
