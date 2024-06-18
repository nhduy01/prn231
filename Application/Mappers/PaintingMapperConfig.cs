using Application.ViewModels.AwardViewModels;
using Application.ViewModels.PaintingViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddPaintingMapperConfig()
    {
        CreateMap<Painting, PaintingViewModel>().ReverseMap();

        CreateMap<Painting, AddPaintingViewModel>().ReverseMap();

        CreateMap<Painting, UpdatePaintingViewModel>().ReverseMap();
    }
}