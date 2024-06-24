using Application.IRepositories;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Account?> Login(string userName)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.UserName == userName && a.Status == AccountStatus.Active.ToString());
    }

    public async Task<Account?> GetByRefreshToken(string token)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.RefreshToken == token);
    }

    public async Task<bool> CheckDuplicate(string email, string phone, string userName)
    {
        return await DbSet.AnyAsync(a => a.Email == email || a.Phone == phone || a.UserName == userName);
    }
}