using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.RoundTopic;
using Application.SendModels.Topic;
using Application.ViewModels.TopicViewModels;
using Domain.Models;

namespace Application.IService
{
    public interface IRoundTopicService
    {
        Task<List<RoundTopicViewModel>> GetListRoundTopic(GetListRoundTopicRequest request); 
        Task<bool> AddTopicToRound(RoundTopicRequest roundTopicRequest);
        Task<bool> DeleteTopicInRound(RoundTopicDeleteRequest roundTopicDeleteRequest);
    }
}
