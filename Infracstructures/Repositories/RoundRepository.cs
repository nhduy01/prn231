using Application.IRepositories;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class RoundRepository : GenericRepository<Round>, IRoundRepository
{
    public RoundRepository(AppDbContext context) : base(context)
    {
    }
    public override async Task<Round?> GetByIdAsync(Guid id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == RoundStatus.Active.ToString());
    }

    public override async Task<List<Round>> GetAllAsync()
    {
        return await DbSet.Where(x => x.Status == RoundStatus.Active.ToString()).ToListAsync();
    }

    public async Task<Round?> GetRoundDetail(Guid id)
    {
        return await DbSet.Include(r => r.EducationalLevel).ThenInclude(e => e.Award).FirstOrDefaultAsync(r => r.Id == id);
    }
    public virtual async Task<List<Topic>> GetTopic(Guid RoundId)
    {
        return await  DbSet.Where(x => x.Id == RoundId && x.Status == RoundStatus.Active.ToString())
            .SelectMany(x => x.RoundTopic.Select(x => x.Topic).Where (x=>x.Status == TopicStatus.Active.ToString()))
            .ToListAsync();
    }
    public async Task<List<Round>> GetRoundByLevelId(Guid levelId)
    {
        return await DbSet.Where(x => x.EducationalLevelId == levelId && x.Status == RoundStatus.Active.ToString()).ToListAsync();
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