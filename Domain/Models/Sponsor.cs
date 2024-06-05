using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Sponsor : BaseModel
    {
        public string Name { get; set; }

        //Relation
        public ICollection<Resources> Resources { get; set; }

    }
}
