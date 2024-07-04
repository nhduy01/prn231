using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.IRepositories
{
    public interface IRoundTopicRepository : IGenericRepository<RoundTopic>
    {
        public Task<List<Painting>> ListPaintingForPreliminaryRound(Guid roundId);

        public Task<List<Painting>> ListPaintingForFinalRound(Guid roundId);


    }
}
