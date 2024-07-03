using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class RoundRepository : GenericRepository<Round>, IRoundRepository
{
    public RoundRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Round?> GetRoundDetail(Guid id)
    {
        return await DbSet.Include(r => r.EducationalLevel).ThenInclude(e => e.Award).FirstOrDefaultAsync(r => r.Id == id);
    }
    public virtual async Task<List<Topic>> GetTopic(Guid RoundId)
    {
        return await  DbSet.Where(x => x.Id == RoundId)
            .SelectMany(x => x.RoundTopic.Select(x => x.Topic))
            .ToListAsync() ;
    }

    public virtual async Task<bool> CheckSubmitValidDate(Guid RoundId)
    {
        var temp =  await DbSet.FirstOrDefaultAsync(x=>x.Id == RoundId);
        bool check=false;
        if((DateTime.Now <= temp.EndTime) && (DateTime.Now >= temp.StartTime)) {
            check = true;
        }
        return check ;
    }
}