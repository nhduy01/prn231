using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Schedule
    {
        public string Description { get; set; }
        public Round? RoundId { get; set; }
        public Account? ExaminerIdS { get; set; }
    }
}
