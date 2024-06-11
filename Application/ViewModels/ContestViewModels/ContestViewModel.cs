using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.ViewModels.ContestViewModels
{
    public class ContestViewModel
    {
        public DateTime CreatedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public Guid? StaffId { get; set; }

        //public ICollection<EducationalLevelViewModel> EducationalLevelViewModels { get; set;}
    }
}
