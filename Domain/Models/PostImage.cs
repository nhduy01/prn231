using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PostImage
    {
        public Painting? ImageId  { get; set; }
        public Collection? PostId { get; set; }
    }
}
