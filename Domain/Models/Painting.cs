using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Painting
    {
        public string Image { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }



        public Account? GradeBy { get; set; }
    }
}
