using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.AccountSendModels;
using Application.SendModels.Authentication;
using Application.SendModels.Category;
using Application.ViewModels.AccountViewModels;
using Application.ViewModels.CategoryViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;
public partial class MapperConfigs : Profile
{
    partial void AddCategoryMapperConfig()
    {
        CreateMap<CategoryRequest, Category>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));
        CreateMap<UpdateCategoryRequest, Category>().ReverseMap()
             .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.UpdatedBy));
        CreateMap<CategoryViewModel, Category>().ReverseMap();
    }
}
