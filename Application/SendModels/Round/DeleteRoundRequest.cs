using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendModels.Round
{
    public class DeleteRoundRequest
    {
        public Guid Id { get; set; }
        public Guid ContestId { get; set; }
        public Guid CurrentUserId { get; set; }
    }
}
