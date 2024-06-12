using Application.SendModels.Authentication;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddCompetitorMapperConfig()
    {
        CreateMap<Competitor, CreateCompetitorRequest>();
    }
}