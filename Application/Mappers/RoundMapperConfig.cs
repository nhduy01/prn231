using Application.SendModels.Round;
using Application.ViewModels.RoundViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddRoundMapperConfig()
    {
        CreateMap<RoundRequest, Round>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy))
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.UpdatedBy));
        CreateMap<RoundUpdateRequest, Round>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.UpdatedBy))
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
        CreateMap<Round, RoundViewModel>()
            .ForPath(dest => dest.EducationalLevelName, opt => opt.MapFrom(src => src.EducationalLevel.Level));
        CreateMap<Round,ListTopicViewModel>().ReverseMap();
    }
}