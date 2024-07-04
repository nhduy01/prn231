using Application.ViewModels.SponsorViewModels;
using AutoMapper;
using Domain.Models;
using Infracstructures.SendModels.Sponsor;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddSponsorMapperConfig()
    {

        CreateMap<Sponsor, SponsorRequest>().ReverseMap()
            .ForMember(x => x.CreatedBy, x => x.MapFrom(x => x.CurrentUserId));

        CreateMap<Sponsor, SponsorUpdateRequest>().ReverseMap()
           .ForMember(x => x.UpdatedBy, x => x.MapFrom(x => x.CurrentUserId));
        CreateMap<Sponsor, SponsorViewModel>().ReverseMap();
    }
}