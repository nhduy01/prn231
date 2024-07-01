using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ReportViewModels
{
    public class ReportViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public Guid? CreatedBy { get; set; }
        public string Status { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CompetitorId { get; set; }
    }
}
