using Application.SendModels.Contest;
using Application.ViewModels.ContestViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddContestMapperConfig()
    {
        CreateMap<Contest, ContestViewModel>().ReverseMap();
        CreateMap<Contest, ContestRequest>().ReverseMap();
        CreateMap<Contest, UpdateContest>().ReverseMap();
    }
}