using AutoMapper;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Application.DTO;

namespace Jostic.Rusia2018.Application.UseCases.Common.Mapgings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            //Para hacer el mapeo entre dto y entidades / viceversa
            //Esta será usado por la capa de aplicación
            CreateMap<Grupo, GrupoDto>().ReverseMap();
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<Pais, GrupoDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
          
        }
    }
}
