using Application.SendModels.Resources;
using Application.ViewModels.ResourcesViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddResourcesMapperConfig()
    {
        CreateMap<ResourcesRequest, Resources>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));

        CreateMap<ResourcesUpdateRequest, Resources>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.UpdatedBy));
        CreateMap<Resources, ResourcesViewModel>().ReverseMap();
    }
}