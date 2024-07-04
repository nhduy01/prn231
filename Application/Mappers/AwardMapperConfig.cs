using Application.ViewModels.AwardViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddAwardMapperConfig()
    {
        CreateMap<Award, AwardViewModel>().ReverseMap();

        CreateMap<Award, AddAwardViewModel>().ReverseMap()
            .ForMember(x=>x.CreatedBy, x=>x.MapFrom(x=>x.CurrentUserId));

        CreateMap<Award, UpdateAwardViewModel>().ReverseMap()
            .ForMember(x => x.UpdatedBy, x => x.MapFrom(x => x.CurrentUserId));
    }
}