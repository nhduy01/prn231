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

    public async Task<Account?> Login(string username)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.Username == username && a.Status == AccountStatus.Active.ToString());
    }

    public async Task<Account?> GetByRefreshToken(string token)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.RefreshToken == token);
    }

    public async Task<bool> CheckDuplicateEmail(string email)
    {
        return await DbSet.AnyAsync(a => a.Email == email);
    }

    public async Task<bool> CheckDuplicatePhone(string phone)
    {
        return await DbSet.AnyAsync(a => a.Phone == phone);
    }

    public async Task<bool> CheckDuplicateUsername(string username)
    {
        return await DbSet.AnyAsync(a => a.Username == username);
    }
}