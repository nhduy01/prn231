using Application.SendModels.Resources;
using Application.ViewModels.ResourcesViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddResourcesMapperConfig()
    {
        CreateMap<ResourcesRequest, Resources>().ReverseMap();
        CreateMap<ResourcesUpdateRequest, Resources>().ReverseMap();
        CreateMap<Resources, ResourcesViewModel>().ReverseMap();
    }
}