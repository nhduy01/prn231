using Application.SendModels.Post;
using AutoMapper;
using Domain.Models;
using Infracstructures.ViewModels.PostViewModels;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddPostMapperConfig()
    {
        CreateMap<Post, PostRequest>().ReverseMap()
            .ForMember(x => x.CreatedBy, x => x.MapFrom(x => x.CurrentUserId))
            .ForMember(x => x.StaffId, x => x.MapFrom(x => x.CurrentUserId));
        CreateMap<Post, PostUpdateRequest>().ReverseMap()
            .ForMember(x => x.UpdatedBy, x => x.MapFrom(x => x.CurrentUserId));
        CreateMap<Post, PostViewModel>().ReverseMap();
    }
}