using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Notification : BaseModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsReaded { get; set; }=false;
        public int AccountId { get; set; }


        //Relation
        public Account Account { get; set; }
    }
}
