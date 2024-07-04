using Application.SendModels.Round;
using Application.ViewModels.RoundViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddRoundMapperConfig()
    {
        CreateMap<RoundRequest, Round>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));
        CreateMap<RoundUpdateRequest, Round>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.UpdatedBy));
        CreateMap<Round, RoundViewModel>().ReverseMap();
        CreateMap<Round,ListTopicViewModel>().ReverseMap();
    }
}