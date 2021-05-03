using Amor.Application.ViewModels;
using Amor.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amor.API.Infrastructure.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Person, PersonViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();

            CreateMap<PersonPhoto, PersonPhotosViewModel>().ReverseMap();
            CreateMap<Photo, PhotoViewModel>().ReverseMap();

            CreateMap<Homeless, HomelessViewModel>()
                .ForMember(h => h.Name, p => p.MapFrom(x => x.Person.Name))                
                .ForMember(h => h.Address, p => p.MapFrom(x => x.Person.Address))                
                .ReverseMap();


            CreateMap<Ong, OngViewModel>()
                .ForMember(h => h.Name, p => p.MapFrom(x => x.Person.Name))
                .ForMember(h => h.Phone, p => p.MapFrom(x => x.Person.Phone))
                .ForMember(h => h.Document, p => p.MapFrom(x => x.Person.LegalPerson.CNPJ))
                .ReverseMap();


            CreateMap<Event, EventViewModel>().ReverseMap();



            //.ForMember(d => d.EstadoNome, opt => opt.MapFrom(x => x.Estado.Nome))
            //.ReverseMap()
            //.ForPath(x => x.Estado.Nome, p => p.Ignore());

            //CreateMap<MarcaViewModel, Marca>().ReverseMap();
        }
    }
}
