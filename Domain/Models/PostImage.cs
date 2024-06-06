using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class PostImage :BaseModel
    {
        public Guid? ImageId  { get; set; }
        public Guid? PostId { get; set; }

        //Relation
        public Image Images { get; set;}

        public Post Post { get; set; }
    }
}
