using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendModels.Painting
{
    public class PaintingRequest2
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid RoundId { get; set; }
        public Guid TopicId { get; set; }
        public Guid CurrentUserId { get; set; }
    }
}
