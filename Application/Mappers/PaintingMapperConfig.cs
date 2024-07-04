using Application.SendModels.Painting;
using Application.ViewModels.PaintingViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddPaintingMapperConfig()
    {
        CreateMap<SendModels.Painting.PaintingRequest, Painting>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));

        CreateMap<Painting, PaintingViewModel>().ReverseMap();

        CreateMap<UpdatePaintingRequest, Painting>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));
    }
}