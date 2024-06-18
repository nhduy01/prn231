using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.PaintingViewModels
{
    public class PaintingViewModel
    {
        public DateTime CreatedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime SubmitTime { get; set; }
        public Guid? AwardId { get; set; }
        public Guid? RoundId { get; set; }
        public Guid? CompetitorId { get; set; }
        public Guid? TopicId { get; set; }
        public Guid? ScheduleId { get; set; }
        public string Code { get; set; }

    }
}
