using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories
{
    public class RoundTopicRepository : GenericRepository<RoundTopic>, IRoundTopicRepository
    {
        public RoundTopicRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<List<Painting>> ListPaintingForPreliminaryRound(Guid roundId)
        {
            return await DbSet.Include(tr => tr.Painting)
                .Where(tr => tr.RoundId == roundId)
                .SelectMany(tr => tr.Painting)
                .Where(p => p.Status == PaintingStatus.Accepted.ToString())
                .OrderByDescending(p => p.UpdatedTime) 
                .ToListAsync();
        }
        
        public async Task<List<Painting>> ListPaintingForFinalRound(Guid roundId)
        {
            return await DbSet
                .Where(tr => tr.RoundId == roundId)
                .Include(tr => tr.Painting)
                .SelectMany(tr => tr.Painting)
                .Where(p => p.Status == PaintingStatus.FinalRound.ToString())
                .OrderByDescending(p => p.UpdatedTime) 
                .ToListAsync();
        }
        
    }
}
