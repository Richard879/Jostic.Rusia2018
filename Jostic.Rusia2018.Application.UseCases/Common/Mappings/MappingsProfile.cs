using AutoMapper;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.UseCases.Grupos.Commands.CreateGrupoCommand;
using Jostic.Rusia2018.Application.UseCases.Grupos.Commands.UpdateGrupoCommand;
using Jostic.Rusia2018.Application.UseCases.Paises.Queries.GetPaisesAllFilter;

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
            CreateMap<Continente, ContinenteDto>().ReverseMap();
            CreateMap<Tecnico, TecnicoDto>().ReverseMap();

            CreateMap<Grupo, CreateGrupoCommand>().ReverseMap();
            CreateMap<Grupo, UpdateGrupoCommand>().ReverseMap();
            CreateMap<Pais, GetPaisesAllFilterQuery>().ReverseMap();

        }
    }
}
