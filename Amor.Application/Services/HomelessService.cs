using Amor.Application.InputModels;
using Amor.Application.ViewModels;
using Amor.Core.Entities;
using Amor.Core.Enums;
using Amor.Core.Interfaces;
using AutoMapper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public class HomelessService : IHomelessService
    {
        private readonly IHomelessRepository _homelessRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public HomelessService(IHomelessRepository homelessRepository,
                               IPersonRepository personRepository,
                               IPhotoRepository photoRepository,
                               IAddressRepository addressRepository,
                               IMapper mapper)
        {
            _homelessRepository = homelessRepository;
            _personRepository = personRepository;
            _photoRepository = photoRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(HomelessInputModel homelessInputModel)
        {
            List<PersonPhoto> personPhotos = new List<PersonPhoto>();

            if (homelessInputModel.Photos != null)
            {
                foreach (var i in homelessInputModel.Photos)
                    personPhotos.Add(new PersonPhoto(new Photo(i)));
            }
                            
            var homelessId = await _homelessRepository.Add(new Homeless(homelessInputModel.Needs, homelessInputModel.About, homelessInputModel.CounterNotFound, new Person(homelessInputModel.Name, "", personPhotos), homelessInputModel.personIdCadastro));
            var homeless = await _homelessRepository.Get(homelessId);            
            await _addressRepository.Add(new Address(homelessInputModel.Address.Longitude,
                                               homelessInputModel.Address.Latitude,
                                               homelessInputModel.Address.Street,
                                               homelessInputModel.Address.Neighborhood,
                                               homelessInputModel.Address.Province,
                                               homelessInputModel.Address.Zip,
                                               homelessInputModel.Address.City,
                                               homelessInputModel.Address.Country,
                                               homelessInputModel.Address.Number,
                                               personId: homeless.PersonId,
                                               eventId: null));

            return homelessId > 0;
        }

        public async Task<HomelessViewModel> Get(int id)
        {
            var response = await _homelessRepository.Get(id);

            if (response == null)
                return null;

            var ret = _mapper.Map<Homeless, HomelessViewModel>(response);

            ret.Photos = new List<string>();
            foreach (var item in response.Person.PersonPhotos)
            {
                ret.Photos.Add(item.Photo.URL);
            }


            if (response.Person.Address.Count() > 0)
            {
                var address = _mapper.Map<Address, AddressViewModel>(response.Person.Address.FirstOrDefault());
                ret.Address = address;
            }

            return ret;
        }

        public async Task<bool> Update(HomelessInputModel homelessInputModel)
        {
            List<PersonPhoto> personPhotos = new List<PersonPhoto>();

            if(homelessInputModel.Photos != null)
            {
                foreach (var i in homelessInputModel.Photos)
                    personPhotos.Add(new PersonPhoto(new Photo(i)));
            }

            var homeless = await _homelessRepository.Get(homelessInputModel.Id);

            homeless.Update(homelessInputModel.Needs, homelessInputModel.About, homelessInputModel.CounterNotFound);
            homeless.Person.Update(homelessInputModel.Name, homelessInputModel.Phone);
            homeless.Person.PersonPhotos = personPhotos;

            var homelessId = await _homelessRepository.Update(homeless);

            var address = await _addressRepository.GetByPersonId(homeless.PersonId);

            if(address != null)
            {
                address.Update(homelessInputModel.Address.Longitude,
                                               homelessInputModel.Address.Latitude,
                                               homelessInputModel.Address.Street,
                                               homelessInputModel.Address.Neighborhood,
                                               homelessInputModel.Address.Province,
                                               homelessInputModel.Address.Zip,
                                               homelessInputModel.Address.City,
                                               homelessInputModel.Address.Country,
                                               homelessInputModel.Address.Number,
                                               personId: homeless.Person.Id,
                                               eventId: null);

                await _addressRepository.Update(address);
            }
            
            return homelessId > 0;
        }
    }
}
