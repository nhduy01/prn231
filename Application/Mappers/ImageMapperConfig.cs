using Application.SendModels.Image;
using Application.ViewModels.PostViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddImageMapperConfig()
    {
        CreateMap<Image, ImageRequest>().ReverseMap();

        CreateMap<Image, ImageInPostVM>().ReverseMap();
    }
}