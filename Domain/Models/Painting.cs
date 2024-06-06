using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Painting : BaseModel
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime SubmitTime { get; set; }
        public Guid? AwardId { get; set; }
        public Guid? RoundId { get; set; }
        public Guid? CompetitorId { get; set;}
        public Guid? TopicId { get; set; }
        public Guid? ScheduleId { get; set; }


        //Relation

        public ICollection<PaintingCollection> PaintingCollection { get; set; }
        public Round Round { get; set; }
        public Award Award { get; set; }    
        public Competitor Competitor { get; set; }
        public Schedule Schedule { get; set; }

    }
}
