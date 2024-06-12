using AutoMapper;
using Domain.Models;
using Infracstructures.SendModels.Sponsor;
using Infracstructures.ViewModels.SponsorViewModels;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddSponsorMapperConfig()
    {
        CreateMap<Sponsor, SponsorRequest>().ReverseMap();
        CreateMap<Sponsor, SponsorUpdateRequest>().ReverseMap();
        CreateMap<SponsorViewModel, Sponsor>().ReverseMap();
    }
}