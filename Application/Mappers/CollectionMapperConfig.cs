using Application.SendModels.Collection;
using Application.ViewModels.CollectionViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddCollectionMapperConfig()
    {
        CreateMap<Collection, CollectionRequest>().ReverseMap()
             .ForMember(x => x.CreatedBy, x => x.MapFrom(x => x.CurrentUserId));
        CreateMap<Collection, CollectionViewModel>().ReverseMap();
        CreateMap<Collection, UpdateCollectionRequest>().ReverseMap()
            .ForMember(x => x.UpdatedBy, x => x.MapFrom(x => x.CurrentUserId));
    }
}