using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Round;
using Application.SendModels.RoundTopic;
using Application.ViewModels.RoundViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;
public partial class MapperConfigs : Profile
{
    partial void AddRoundTopicMapperConfig()
    {
        CreateMap<RoundTopic, RoundTopicRequest>().ReverseMap();
        CreateMap<RoundTopic, RoundTopicViewModel>()
            .ForMember(des => des.Id, source => source.MapFrom(round => round.RoundId))
            .ForMember(des => des.Name, source => source.MapFrom(round => round.Topic.Name));

        CreateMap<RoundTopic, RoundTopicInContestViewModel>()
            .ForMember(x => x.Topic, x => x.MapFrom(x => x.Topic));
    }
}
