using AutoMapper;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.UseCases.Groups.Commands.CreateGrupoCommand;
using Jostic.Rusia2018.Application.UseCases.Groups.Commands.UpdateGrupoCommand;
using Jostic.Rusia2018.Application.UseCases.Countries.Queries.GetCountriesAllFilter;
using Jostic.Rusia2018.Application.UseCases.Countrys.Commands.CreateCountryCommand;
using Jostic.Rusia2018.Application.UseCases.Continents.Commands.UpdateContinentCommand;
using Jostic.Rusia2018.Application.UseCases.Continents.Commands.CreateContinentCommand;
using Jostic.Rusia2018.Application.UseCases.Technicals.Commands.CreateTechnicalCommand;
using Jostic.Rusia2018.Application.UseCases.Technicals.Commands.UpdateTechnicalCommand;
using Jostic.Rusia2018.Application.UseCases.Phases.Commands.CreatePhaseCommand;
using Jostic.Rusia2018.Application.UseCases.Phases.Commands.UpdatePhaseCommand;

namespace Jostic.Rusia2018.Application.UseCases.Common.Mapgings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            //Para hacer el mapeo entre dto y entidades / viceversa
            //Esta será usado por la capa de aplicación
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, GroupDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Continent, ContinentDto>().ReverseMap();
            CreateMap<Technical, TechnicalDto>().ReverseMap();
            CreateMap<Phase, PhaseDto>().ReverseMap();

            CreateMap<Group, CreateGroupCommand>().ReverseMap();
            CreateMap<Group, UpdateGroupCommand>().ReverseMap();
            CreateMap<Continent, CreateContinentCommand>().ReverseMap();
            CreateMap<Continent, UpdateContinentCommand>().ReverseMap();
            CreateMap<Technical, CreateTechnicalCommand>().ReverseMap();
            CreateMap<Technical, UpdateTechnicalCommand>().ReverseMap();
            CreateMap<Phase, CreatePhaseCommand>().ReverseMap();
            CreateMap<Phase, UpdatePhaseCommand>().ReverseMap();
            CreateMap<Country, GetCountryAllFilterQuery>().ReverseMap();
            CreateMap<Country, CreateCountryCommand>().ReverseMap();

        }
    }
}