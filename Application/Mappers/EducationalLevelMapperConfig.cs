using Application.SendModels.EducationalLevel;
using Application.SendModels.Round;
using Application.ViewModels.EducationalLevelViewModels;
using Application.ViewModels.RoundViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddEducationalLevelMapperConfig()
    {
        CreateMap<EducationalLevel, EducationalLevelRequest>().ReverseMap()
            .ForMember(x => x.CreatedBy, x => x.MapFrom(x => x.CurrentUserId));
        CreateMap<EducationalLevel, EducationalLevelUpdateRequest>().ReverseMap()
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
        CreateMap<EducationalLevel, EducationalLevelViewModel>().ReverseMap();
    }
}