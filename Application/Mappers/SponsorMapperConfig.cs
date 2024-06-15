using Application.ViewModels.SponsorViewModels;
using AutoMapper;
using Domain.Models;
using Infracstructures.SendModels.Sponsor;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddSponsorMapperConfig()
    {
        CreateMap<SponsorRequest,Sponsor>().ReverseMap();
        CreateMap<SponsorUpdateRequest,Sponsor>().ReverseMap();
        CreateMap<Sponsor, SponsorViewModel>().ReverseMap();
    }
}