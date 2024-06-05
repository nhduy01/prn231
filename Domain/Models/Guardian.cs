using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Guardian : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Relationship { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public string IdentifyNumber { get; set; }
        public bool Gender { get; set; } = true;
        public int CompetitorId { get ; set; }

        //Relation
        public Account Account { get; set; }

        
    }
}
