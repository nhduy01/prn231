using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.SendModels.Category
{
    public class CategoryRequest
    {
        public Guid CurrentUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
