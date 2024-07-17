using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendModels.Painting
{
    public class FilterPaintingRequest
    {
        public string? Code {  get; set; }
        public string? TopicName {  get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Level {  get; set; }
        public string? RoundName { get; set; }
        public string? Status { get; set; }
        //public Guid ContestId { get; set; }
    }
}
