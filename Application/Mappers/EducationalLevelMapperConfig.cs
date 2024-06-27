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
        CreateMap<EducationalLevelRequest, EducationalLevel>().ReverseMap();
        CreateMap<EducationalLevelUpdateRequest, EducationalLevel>().ReverseMap();
        CreateMap<EducationalLevel, EducationalLevelViewModel>().ReverseMap();
    }
}