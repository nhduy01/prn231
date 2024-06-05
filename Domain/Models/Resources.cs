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
        public int SponsorId { get; set; }
        public int ContestId { get; set; }


        //Relation

        public Contest Contest { get; set; }

        public Sponsor Sponsor { get; set; }
    }
}
