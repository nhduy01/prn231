using Application.ViewModels.ScheduleViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddAwardScheduleMapperConfig()
    {
        CreateMap<AwardSchedule, AwardScheduleListModels>()
            .ForMember(dest => dest.PaintingViewModelsList, opt => opt.MapFrom(src => src.Schedule.Painting));

    }
}

