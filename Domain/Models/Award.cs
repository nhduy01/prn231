using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Award : BaseModel
    {
        public string Rank { get; set; }
        public int Quantity { get; set; }
        public Double Cash { get; set; }
        public string Artifact { get; set; }
        public string Description { get; set; }
        public int EducationalLevelId {  get; set; }


        //Relation
        public EducationalLevel? EducationalLevel { get; set; }
        public ICollection<Painting> Painting { get; set; }
    }
}
