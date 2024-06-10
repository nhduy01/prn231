using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AwardViewModels
{
    public class UpdateAwardViewModel
    {
        public Guid Id { get; set; }
        public string Rank { get; set; }
        public int Quantity { get; set; }
        public Double Cash { get; set; }
        public string Artifact { get; set; }
        public string Description { get; set; }
        public Guid? EducationalLevelId { get; set; }
    }
}
