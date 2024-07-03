using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories
{
    public class RoundTopicRepository : GenericRepository<RoundTopic>, IRoundTopicRepository
    {
        public RoundTopicRepository(AppDbContext context) : base(context)
        {
        }
    }
}
