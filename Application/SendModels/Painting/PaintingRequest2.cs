using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendModels.Painting
{
    public class PaintingRequest2
    {
        public string Image { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid RoundId { get; set; }
        public Guid TopicId { get; set; }
        public Guid CurrentUserId { get; set; }
    }
}
