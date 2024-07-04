using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.AccountSendModels;
using Application.SendModels.Authentication;
using Application.ViewModels.AccountViewModels;
using Application.ViewModels.CategoryViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;
public partial class MapperConfigs : Profile
{
    partial void AddCategoryMapperConfig()
    {
        CreateMap<AddCategoryViewModel, Category>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));
        CreateMap<UpdateCategoryViewModel, Category>().ReverseMap()
             .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.UpdatedBy));
        CreateMap<CategoryViewModel, Category>().ReverseMap();
    }
}
