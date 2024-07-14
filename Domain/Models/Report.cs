using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Report : BaseModel
    {
        public string? Title {  get; set; }
        public string? Description { get; set; }
        public Guid CompetitorId { get; set; }


        public Account Account { get; set; }


    }
}
