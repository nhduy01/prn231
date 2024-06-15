using Application.SendModels.Post;
using AutoMapper;
using Domain.Models;
using Infracstructures.ViewModels.PostViewModels;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddPostMapperConfig()
    {
        CreateMap<PostRequest,Post>() .ReverseMap();
        CreateMap<PostUpdateRequest,Post>().ReverseMap();
        CreateMap<Post, PostViewModel>().ReverseMap();
    }
}