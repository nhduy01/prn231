using Application.ViewModels.AwardViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddAwardMapperConfig()
    {
        CreateMap<Award, AwardViewModel>().ReverseMap();

        CreateMap<Award, AddAwardViewModel>().ReverseMap();

        CreateMap<Award, UpdateAwardViewModel>().ReverseMap();
    }
}