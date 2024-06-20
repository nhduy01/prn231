using Application.SendModels.Round;
using Application.ViewModels.RoundViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddRoundMapperConfig()
    {
        CreateMap<RoundRequest, Round>().ReverseMap();
        CreateMap<RoundUpdateRequest, Round>().ReverseMap();
        CreateMap<Round, RoundViewModel>().ReverseMap();
    }
}