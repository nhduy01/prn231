using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Post : BaseModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? StaffId { get; set; }

        //Relation
        public ICollection<PostImage> PostImages { get; set; }
        public Account Account { get; set; }
    }
}
