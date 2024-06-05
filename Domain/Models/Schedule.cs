using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Schedule : BaseModel
    {
        public string Description { get; set; }
        public int? RoundId { get; set; }
        public int? ExaminerId { get; set; }


        //Relation

        public Round Round { get; set; }

        public Account Account { get; set; }
    }
}
