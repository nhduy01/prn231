using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Resources :BaseModel
    {
        public string Cash { get; set; }
        public string Artifact { get; set; }
        public Guid? SponsorId { get; set; }
        public Guid? ContestId { get; set; }


        //Relation

        public Contest Contest { get; set; }

        public Sponsor Sponsor { get; set; }
    }
}
