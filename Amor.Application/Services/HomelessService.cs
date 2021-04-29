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
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public class HomelessService : IHomelessService
    {
        private readonly IHomelessRepository _homelessRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;

        public HomelessService(IHomelessRepository homelessRepository, IPersonRepository personRepository, IPhotoRepository photoRepository, IMapper mapper)
        {
            _homelessRepository = homelessRepository;
            _personRepository = personRepository;
            _photoRepository = photoRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(HomelessInputModel homelessInputModel)
        {
            List<PersonPhoto> personPhotos = new List<PersonPhoto>();
            foreach (var i in homelessInputModel.Photos)
                personPhotos.Add(new PersonPhoto(new Photo(i)));
            
            var homelessId = await _homelessRepository.Add(new Homeless(homelessInputModel.Needs, homelessInputModel.About, 0, new Person(homelessInputModel.Name, "", personPhotos)));
            return homelessId > 0;
        }

        public async Task<HomelessViewModel> Get(int id)
        {
            var response = await _homelessRepository.Get(id);
            var ret = _mapper.Map<Homeless, HomelessViewModel>(response);

            ret.Photos = new List<string>();
            foreach (var item in response.Person.PersonPhotos)
            {
                ret.Photos.Add(item.Photo.URL);
            }
            return ret;
        }

        public async Task<bool> Update(HomelessInputModel homelessInputModel)
        {
            List<PersonPhoto> personPhotos = new List<PersonPhoto>();
            foreach (var i in homelessInputModel.Photos)
                personPhotos.Add(new PersonPhoto(new Photo(i)));

            var homeless = await _homelessRepository.Get(homelessInputModel.Id);

            homeless.Update(homelessInputModel.Needs, homelessInputModel.About);
            homeless.Person.Update(homelessInputModel.Name, homelessInputModel.Phone);
            homeless.Person.PersonPhotos = personPhotos;

            var homelessId = await _homelessRepository.Update(homeless);

            return homelessId > 0;
        }
    }
}
