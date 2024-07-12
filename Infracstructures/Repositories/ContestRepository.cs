using System.Diagnostics;
using Application.IRepositories;
using Application.ViewModels.ContestViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class ContestRepository : GenericRepository<Contest>, IContestRepository
{
    public ContestRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<List<Contest>> GetAllAsync()
    {
        return await DbSet.Where(x=>x.Status != ContestStatus.Inactive.ToString())
            .Include(x=>x.Account)
            .ToListAsync();
    }
    public async Task<Contest?> GetAllContestInformationAsync(Guid contestId)
    {

        return await DbSet
            .Where(x => x.Status != ContestStatus.Inactive.ToString())
            .Include(x => x.Resources.Where(x => x.Status != ResourcesStatus.Inactive.ToString()))
            .ThenInclude(x => x.Sponsor)
            .Include(x => x.EducationalLevel.Where(x => x.Status != EducationalLevelStatus.Inactive.ToString()))
            .ThenInclude(x => x.Round)
            .ThenInclude(x=>x.RoundTopic)
            .ThenInclude(x => x.Topic)
            .Include(x => x.EducationalLevel.Where(x => x.Status != EducationalLevelStatus.Inactive.ToString()))
            .ThenInclude(x => x.Award)
            .Include(x=>x.Account)
            .FirstOrDefaultAsync(x => x.Id == contestId);
    }

    public async Task<Contest?> GetNearestContestInformationAsync()
    {

        return await DbSet
            .Where(x => x.Status != ContestStatus.Inactive.ToString())
            .Include(x => x.Resources.Where(x => x.Status != ResourcesStatus.Inactive.ToString()))
            .ThenInclude(x => x.Sponsor)
            .Include(x => x.EducationalLevel.Where(x => x.Status != EducationalLevelStatus.Inactive.ToString()))
            .ThenInclude(x => x.Round)
            .ThenInclude(x => x.RoundTopic)
            .ThenInclude(x => x.Topic)
            .Include(x => x.EducationalLevel.Where(x => x.Status != EducationalLevelStatus.Inactive.ToString()))
            .ThenInclude(x => x.Award)
            .Include(x => x.Account)
            .OrderBy(x=>x.CreatedTime)
            .FirstOrDefaultAsync();
    }

    public async Task<List<int>> Get5RecentYearAsync()
    {
        var result = DbSet.Select(x => x.CreatedTime.Year).Take(5).ToListAsync();
        return await result;
    }

    public async Task<(DateTime StartTime, DateTime EndTime)?> GetStartEndTimeByContestId(Guid contestId) 
    {
        var round = await DbSet
           .Where(c => c.Status != ContestStatus.Inactive.ToString())
           .Include(c => c.EducationalLevel.Where(l => l.Status != EducationalLevelStatus.Inactive.ToString()))
               .ThenInclude(l => l.Round)
           .SelectMany(c => c.EducationalLevel)
           .SelectMany(l => l.Round)
           .Select(r => new { r.StartTime, r.EndTime })
           .FirstOrDefaultAsync();

        return round != null ? (round.StartTime, round.EndTime) : (DateTime.MinValue, DateTime.MinValue);
    }

    public async Task<List<Guid>> Get3NearestContestId()
    {
        var result = DbSet.OrderBy(x => x.CreatedTime).Select(x => x.Id).Take(3).ToListAsync();
        return await result;
    }
}