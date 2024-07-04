using Application.SendModels.Contest;
using Application.ViewModels.ContestViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddContestMapperConfig()
    {
        CreateMap<Contest, ContestViewModel>().ReverseMap();
        CreateMap<Contest, ContestRequest>().ReverseMap()
            .ForMember(x => x.CreatedBy, x => x.MapFrom(x => x.CurrentUserId))
            .ForMember(x => x.StaffId, x => x.MapFrom(x => x.CurrentUserId));

        CreateMap<Contest, UpdateContest>().ReverseMap()
            .ForMember(x => x.UpdatedBy, x => x.MapFrom(x => x.CurrentUserId));
    }
}