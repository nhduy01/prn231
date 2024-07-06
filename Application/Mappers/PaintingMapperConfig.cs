using Application.SendModels.Painting;
using Application.ViewModels.PaintingViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddPaintingMapperConfig()
    {
        CreateMap<Painting, PaintingRequest>().ReverseMap()
            .ForMember(x => x.CreatedBy, x => x.MapFrom(x => x.CurrentUserId));

        CreateMap<Painting, PaintingRequest2>().ReverseMap()
            .ForMember(x => x.CreatedBy, x => x.MapFrom(x => x.CurrentUserId))
            .ForMember(x => x.AccountId, x => x.MapFrom(x => x.CurrentUserId));

        CreateMap<Painting, PaintingViewModel>()
            .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Account.FullName));

        CreateMap<PaintingViewModel, Painting>()
            .ForPath(dest => dest.Account.FullName, opt => opt.MapFrom(src => src.OwnerName));

        CreateMap<UpdatePaintingRequest, Painting>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));


    }
}