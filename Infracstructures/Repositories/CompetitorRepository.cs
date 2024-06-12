using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class CompetitorRepository : GenericRepository<Competitor>, ICompetitorRepository
{
    public CompetitorRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(
        context, timeService, claimsService)
    {
    }

    public async Task<Competitor?> Login(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<bool> CheckDuplicate(string email, string phone)
    {
        return await _dbSet.AnyAsync(a => a.Email == email || a.Phone == phone);
    }
}