using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendModels.RoundTopic
{
    public class RoundTopicDeleteRequest
    {
        public Guid RoundId { get; set; }
        public Guid TopicId { get; set; }
    }
}
