using Application.IRepositories;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class CompetitorRepository : GenericRepository<Competitor>, ICompetitorRepository
{
    public CompetitorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Competitor?> Login(string email)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.Email == email && a.Status == AccountStatus.ACTIVE.ToString());
    }

    public Task<Competitor?> GetByRefreshToken(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CheckDuplicate(string email, string phone)
    {
        return await DbSet.AnyAsync(a => a.Email == email || a.Phone == phone);
    }
}