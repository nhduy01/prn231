﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RoundTopic
    {
        public Guid Id { get; set; }
        public Guid? RoundId { get; set; }
        public Guid? TopicId { get; set; }

        //Relation
        public Round Round { get; set; }
        public Topic Topic { get; set; }
        public ICollection<Painting> Painting { get; set; }
    }
}
