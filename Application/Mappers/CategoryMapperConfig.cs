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
        CreateMap<Category, CategoryRequest>().ReverseMap()
            .ForMember(x => x.CreatedBy, x => x.MapFrom(x => x.CurrentUserId));
        
        
        CreateMap<Category, UpdateCategoryRequest>().ReverseMap()
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
        CreateMap<CategoryViewModel, Category>();

        CreateMap<Category, CategoryViewModel>();
    }
}
