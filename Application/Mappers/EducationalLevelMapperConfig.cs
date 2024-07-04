using Application.SendModels.EducationalLevel;
using Application.SendModels.Round;
using Application.ViewModels.EducationalLevelViewModels;
using Application.ViewModels.RoundViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddEducationalLevelMapperConfig()
    {
        CreateMap<EducationalLevelRequest, EducationalLevel>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));
        CreateMap<EducationalLevelUpdateRequest, EducationalLevel>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.UpdatedBy));
        CreateMap<EducationalLevel, EducationalLevelViewModel>().ReverseMap();
    }
}