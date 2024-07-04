using Application.ViewModels.CollectionViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddCollectionMapperConfig()
    {
        CreateMap<Collection, AddCollectionViewModel>().ReverseMap()
             .ForMember(x => x.CreatedBy, x => x.MapFrom(x => x.CurrentUserId));
        CreateMap<Collection, CollectionViewModel>().ReverseMap();
        CreateMap<Collection, UpdateCollectionViewModel>().ReverseMap()
            .ForMember(x => x.UpdatedBy, x => x.MapFrom(x => x.CurrentUserId));
    }
}