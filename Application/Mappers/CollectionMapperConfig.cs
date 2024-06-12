using Application.ViewModels.CollectionViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddCollectionMapperConfig()
    {
        CreateMap<Collection, AddCollectionViewModel>().ReverseMap();
        CreateMap<Collection, CollectionViewModel>().ReverseMap();
        CreateMap<Collection, UpdateCollectionViewModel>().ReverseMap();
    }
}