using Application.ViewModels.SponsorViewModels;
using AutoMapper;
using Domain.Models;
using Infracstructures.SendModels.Sponsor;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddSponsorMapperConfig()
    {
        CreateMap<SponsorRequest, Sponsor>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));

        CreateMap<SponsorUpdateRequest, Sponsor>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.UpdatedBy));
        CreateMap<Sponsor, SponsorViewModel>().ReverseMap();
    }
}