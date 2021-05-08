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
    public class OngService : IOngService
    {
        private readonly IOngRepository _ongRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public OngService(IOngRepository ongRepository,
                               IPersonRepository personRepository,
                               IPhotoRepository photoRepository,
                               IAddressRepository addressRepository,
                               IUserRepository userRepository,
                               IMapper mapper)
        {
            _ongRepository = ongRepository;
            _personRepository = personRepository;
            _photoRepository = photoRepository;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IList<SearchByNameViewModel>> GetByName(string name)
        {
            List<SearchByNameViewModel> searchByNames = new List<SearchByNameViewModel>();

            var ongs = await _ongRepository.GetByName(name);

            foreach (var i in ongs)
                searchByNames.Add(new SearchByNameViewModel()
                {
                    Id = i.Id,
                    Name = i.Person.Name,
                    Type = "ONG"
                });

            return searchByNames;
        }

        public async Task<OngViewModel> GetByPersonId(int id)
        {
            var response = await _ongRepository.GetByPersonId(id);

            if (response == null)
                return null;

            var ret = _mapper.Map<Ong, OngViewModel>(response);

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

            ret.Supporters = new List<string>();
            foreach(var item in response.Supporters)
            {                
                if(!item.Donation.AnonymousDonation)
                    ret.Supporters.Add(item.Donation.Person.Name);
            }

            ret.OpeningTime = response.OpeningTime?.ToString("hh:mm");
            ret.ClosingTime = response.ClosingTime?.ToString("hh:mm");

            return ret;
        }

        public async Task<bool> Update(OngInputModel ongInputModel)
        {
            List<PersonPhoto> personPhotos = new List<PersonPhoto>();
            foreach (var i in ongInputModel.Photos)
                personPhotos.Add(new PersonPhoto(new Photo(i)));

            var ong = await _ongRepository.GetByPersonId(ongInputModel.personId);

            ong.Update(Convert.ToDateTime(ongInputModel.OpeningTime), Convert.ToDateTime(ongInputModel.ClosingTime), ongInputModel.PageProfileLink, ongInputModel.About);
            ong.Person.Update(ongInputModel.Name, ongInputModel.Phone);
            ong.Person.PersonPhotos = personPhotos;

            var ongId = await _ongRepository.Update(ong);

            var address = await _addressRepository.GetByPersonId(ongInputModel.personId);

            if (address != null)
            {
                address.Update(ongInputModel.Address.Longitude,
                                               ongInputModel.Address.Longitude,
                                               ongInputModel.Address.AddressDesc,
                                               ongInputModel.Address.Neighborhood,
                                               ongInputModel.Address.Province,
                                               ongInputModel.Address.Zip,
                                               ongInputModel.Address.City,
                                               personId: ong.Person.Id,
                                               eventId: null);

                await _addressRepository.Update(address);
            }
            else
            {
                await _addressRepository.Add(new Address(ongInputModel.Address.Longitude,
                                               ongInputModel.Address.Longitude,
                                               ongInputModel.Address.AddressDesc,
                                               ongInputModel.Address.Neighborhood,
                                               ongInputModel.Address.Province,
                                               ongInputModel.Address.Zip,
                                               ongInputModel.Address.City,
                                               personId: ong.Person.Id,
                                               eventId: null));
            }

            return ongId > 0;
        }
    }
}
