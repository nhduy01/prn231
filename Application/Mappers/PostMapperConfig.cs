﻿using Application.SendModels.Post;
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
            .ForMember(x => x.UpdatedBy, x => x.MapFrom(x => x.CurrentUserId))
            .ForAllMembers(opt =>
            {
                opt.Condition((src, dest, srcMember) => srcMember != null); // Kiểm tra srcMember không null
                opt.Condition((src, dest, srcMember, destMember) => // Kiểm tra nếu là Guid thì không Empty
                {
                    if (srcMember is Guid guidValue)
                    {
                        return guidValue != Guid.Empty;
                    }
                    return true; // Cho phép ánh xạ nếu không phải kiểu Guid
                });
            });
        CreateMap<Post, PostViewModel>().ReverseMap()
            .ForPath(x => x.Category.Id, x => x.MapFrom(x => x.CategoryId))
            .ForPath(x => x.Category.Name, x => x.MapFrom(x => x.CategoryName));
    }
}