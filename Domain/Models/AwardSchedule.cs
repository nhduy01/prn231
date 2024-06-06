using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class AwardSchedule : BaseModel
    {
        public int Quantity { get; set; }
        public Guid? AwardId { get; set; }
        public Guid? ScheduleId { get; set; }
        //Relation
        public Award Award { get; set; }
        public Schedule Schedule { get; set; }
    }
}
