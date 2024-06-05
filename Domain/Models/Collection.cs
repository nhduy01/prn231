using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Collection : BaseModel
    {
        

        public string Name { get; set; }
        public string Image { get; set; }

        public string Description { get; set; }
        public int? AccountId { get; set; }


        //Relation 
        public Account Account { get; set; }

        public ICollection<PaintingCollection> PaintingCollection { get; set; }
    }
}
