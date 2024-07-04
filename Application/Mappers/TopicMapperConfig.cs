using Application.SendModels.Topic;
using Application.ViewModels.TopicViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddTopicMapperConfig()
    {
        CreateMap<TopicRequest, Topic>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.CreatedBy));
        CreateMap<TopicUpdateRequest, Topic>().ReverseMap()
            .ForMember(x => x.CurrentUserId, x => x.MapFrom(x => x.UpdatedBy));
        CreateMap<Topic, TopicViewModel>().ReverseMap();
    }
}