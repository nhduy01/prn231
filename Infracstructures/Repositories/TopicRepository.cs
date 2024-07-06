using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;

namespace Infracstructures.Repositories;

public class TopicRepository : GenericRepository<Topic>, ITopicRepository
{
    public TopicRepository(AppDbContext context) : base(context)
    {
    }
    public override async Task<Topic?> GetByIdAsync(Guid id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == TopicStatus.Active.ToString());
    }

    public override async Task<List<Topic>> GetAllAsync()
    {
        return await DbSet.Where(x => x.Status == TopicStatus.Active.ToString()).ToListAsync();
    }
}