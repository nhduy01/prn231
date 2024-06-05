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
        public int? GradeBy { get; set; }
        public DateTime SubmitTime { get; set; }
        public int? AwardId { get; set; }
        public int? RoundId { get; set; }
        public int? CompetitorId { get; set;}
        public int? TopicId { get; set;}

        //Relation

        public ICollection<PaintingCollection> PaintingCollection { get; set; }
        public Round Round { get; set; }
        public Award Award { get; set; }    
        public Account Account { get; set; }
    }
}
