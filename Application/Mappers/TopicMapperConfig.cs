using Application.SendModels.Topic;
using Application.ViewModels.TopicViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddTopicMapperConfig()
    {
        CreateMap<TopicRequest, Topic>().ReverseMap();
        CreateMap<TopicUpdateRequest, Topic>().ReverseMap();
        CreateMap<Topic, TopicViewModel>().ReverseMap();
    }
}