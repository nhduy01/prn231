using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendModels.Report
{
    public class ReportRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CurrentUserId { get; set; }

    }
}
