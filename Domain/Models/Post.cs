using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }




        public Account? StaffId { get; set; }
    }
}
