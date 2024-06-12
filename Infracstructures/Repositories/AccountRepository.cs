using Domain.Models;
using Application.IRepositories;
using Application.IService.ICommonService;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(
        context, timeService, claimsService)
    {
    }

    public async Task<Account?> Login(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<Account?> GetByRefreshToken(string token)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.RefreshToken == token);
    }

    public async Task<bool> CheckDuplicate(string email, string phone)
    {
        return await _dbSet.AnyAsync(a => a.Email == email || a.Phone == phone);
    }
}