﻿using Application.IRepositories;
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
        return await DbSet.Where(x => x.Status != ContestStatus.Inactive.ToString())
            .Include(x => x.Account)
            .ToListAsync();
    }

    public override async Task<Contest?> GetByIdAsync(Guid id)
    {
        return await DbSet
            .Include(x => x.Resources)
            .ThenInclude(x => x.Sponsor)
            .Include(x => x.EducationalLevel)
            .ThenInclude(x => x.Round)
            .ThenInclude(x => x.RoundTopic)
            .ThenInclude(x => x.Topic)
            .Include(x => x.EducationalLevel)
            .ThenInclude(x => x.Award)
            .Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == id && x.Status != ContestStatus.Inactive.ToString());
        ;
    }

    public async Task<Contest?> GetAllContestInformationAsync(Guid contestId)
    {
        var contest = await DbSet
            .Include(x => x.Resources.Where(x => x.Status != ResourcesStatus.Inactive.ToString()))
            .ThenInclude(x => x.Sponsor)
            .Include(x => x.EducationalLevel.Where(x => x.Status != EducationalLevelStatus.Inactive.ToString()))
            .ThenInclude(x => x.Round.Where(x => x.Status != RoundStatus.Inactive.ToString()))
            .ThenInclude(x => x.RoundTopic)
            .ThenInclude(x => x.Topic)
            .Include(x => x.EducationalLevel.Where(x => x.Status != EducationalLevelStatus.Inactive.ToString()))
            .ThenInclude(x => x.Award.Where(x => x.Status != AwardStatus.Inactive.ToString()))
            .Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == contestId && x.Status != ContestStatus.Inactive.ToString());
        if (contest != null)
            // Lọc các RoundTopic có Topic.Status == "Active"
            foreach (var educationalLevel in contest.EducationalLevel)
            foreach (var round in educationalLevel.Round)
                round.RoundTopic = round.RoundTopic.Where(rt => rt.Topic.Status == TopicStatus.Active.ToString())
                    .ToList();
        return contest;
    }

    public async Task<Contest?> GetNearestContestInformationAsync()
    {
        return await DbSet
            .Include(x => x.Resources.Where(x => x.Status != ResourcesStatus.Inactive.ToString()))
            .ThenInclude(x => x.Sponsor)
            .Include(x => x.EducationalLevel.Where(x => x.Status != EducationalLevelStatus.Inactive.ToString()))
            .ThenInclude(x => x.Round)
            .ThenInclude(x => x.RoundTopic)
            .ThenInclude(x => x.Topic)
            .Include(x => x.EducationalLevel.Where(x => x.Status != EducationalLevelStatus.Inactive.ToString()))
            .ThenInclude(x => x.Award)
            .Include(x => x.Account)
            .OrderBy(x => x.CreatedTime)
            .FirstOrDefaultAsync(x => x.Status != ContestStatus.Inactive.ToString());
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

    public async Task<Contest?> GetContestByIdForRoundTopic(Guid id)
    {
        var result = await DbSet.Include(c => c.EducationalLevel).ThenInclude(e => e.Round)
            .ThenInclude(r => r.RoundTopic)
            .ThenInclude(rt => rt.Topic).FirstOrDefaultAsync(c => c.Id.Equals(id));
        return result;
    }

    public async Task<List<Contest>> EndContest()
    {
        return await DbSet.Where(src => src.EndTime <= DateTime.Now && src.Status == ContestStatus.Active.ToString()).ToListAsync();
    }

    public async Task<List<Contest>> StartContest()
    {
        return await DbSet.Where(src => src.StartTime >= DateTime.Now && src.Status == ContestStatus.Active.ToString()).ToListAsync();
    }
}