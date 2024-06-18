using Application.SendModels.Painting;
using Application.ViewModels.PaintingViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddPaintingMapperConfig()
    {
        CreateMap<PaintingRequest, Painting>();
        
        CreateMap<Painting, PaintingViewModel>().ReverseMap();

        CreateMap<Painting, UpdatePaintingViewModel>().ReverseMap();
    }
}