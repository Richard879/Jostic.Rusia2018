using AutoMapper;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Application.DTO;

namespace Jostic.Rusia2018.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            //Para hacer el mapeo entre dto y entidades / viceversa
            //Esta será usado por la capa de aplicación
            CreateMap<Grupo, GrupoDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            //CreateMap<Customers, CustomersDTO>().ReverseMap()
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName)).ReverseMap();
        }
    }
}
