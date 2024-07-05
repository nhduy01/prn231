using Application.SendModels.Image;
using Application.SendModels.Post;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddImageMapperConfig()
    {
        CreateMap<Image, ImageRequest>().ReverseMap();
    }
}