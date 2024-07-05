using Application.SendModels.PaintingCollection;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddPaintingCollectionMapperConfig()
    {
        CreateMap<PaintingCollection, PaintingCollectionRequest>().ReverseMap();
    }
}