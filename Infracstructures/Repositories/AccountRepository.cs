using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Account?> Login(string email)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<Account?> GetByRefreshToken(string token)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.RefreshToken == token);
    }

    public async Task<bool> CheckDuplicate(string email, string phone)
    {
        return await DbSet.AnyAsync(a => a.Email == email || a.Phone == phone);
    }
}