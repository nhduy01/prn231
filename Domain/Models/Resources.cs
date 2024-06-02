using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Resources
    {
        public string Cash { get; set; }
        public string Artifact { get; set; }









        public Sponsor? SponsorId { get; set; }
        public Contest? ContestId { get; set; }
    }
}
