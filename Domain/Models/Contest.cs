using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Contest : BaseModel
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public Guid? StaffId { get; set; }



        //Relation
        public Account Account { get; set; }
        
        public ICollection<EducationalLevel> EducationalLevel { get; set; }
        public ICollection<Resources> Resources { get; set; }
    }
}
