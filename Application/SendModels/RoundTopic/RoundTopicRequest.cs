using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendModels.RoundTopic
{
    public class RoundTopicRequest
    {
        public Guid RoundId { get; set; }
        public List<Guid> ListTopicId { get; set; }
    }
}
