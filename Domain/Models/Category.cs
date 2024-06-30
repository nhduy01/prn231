using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid StaffId { get; set; }

        public ICollection<Post> Post { get; set;}
        public Account Account { get; set; }
    }
}
