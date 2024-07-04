using Application.SendModels.Schedule;
using Application.ViewModels.ScheduleViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddScheduleMapperConfig()
    {
        CreateMap<ScheduleRequest, Schedule>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));
        CreateMap<ScheduleUpdateRequest, Schedule>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.UpdatedBy));
        CreateMap<Schedule, ScheduleViewModel>();
        CreateMap<Schedule, ScheduleRatingViewModel>();
    }
}