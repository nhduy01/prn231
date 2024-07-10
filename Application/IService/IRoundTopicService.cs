using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.RoundTopic;

namespace Application.IService
{
    public interface IRoundTopicService
    {
        Task<bool> AddTopicToRound(RoundTopicRequest roundTopicRequest);
        Task<bool> DeleteTopicInRound(Guid id);
    }
}
