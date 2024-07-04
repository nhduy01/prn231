using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendModels.EducationalLevel
{
    public class EducationalLevelRequest
    {
        public string Description { get; set; }
        public string EducationLevel { get; set; }
        public Guid ContestId { get; set; }
        public Guid CurrentUserId { get; set; }

    }
}
