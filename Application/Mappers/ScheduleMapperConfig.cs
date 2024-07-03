using Application.SendModels.Schedule;
using Application.ViewModels.ScheduleViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddScheduleMapperConfig()
    {
        CreateMap<ScheduleRequest, Schedule>().ReverseMap();
        CreateMap<ScheduleUpdateRequest, Schedule>().ReverseMap();
        CreateMap<Schedule, ScheduleViewModel>();
        CreateMap<Schedule, ScheduleRatingViewModel>();
    }
}