using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Round : BaseModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int EducationalLevelId { get; set; }


        //Relation
        public EducationalLevel EducationalLevel { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
        public ICollection<Topic> Topic { get; set; }
        public ICollection<Painting> Painting { get; set; }
    }
}
