﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Image : BaseModel
    {
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
