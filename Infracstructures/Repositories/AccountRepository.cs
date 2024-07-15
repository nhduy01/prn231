using Application.IRepositories;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infracstructures.Repositories;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<Account?> GetByIdAsync(Guid id)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.Id == id && a.Status == AccountStatus.Active.ToString());
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

    public async Task<List<Account>> GetAccountByListAccountId(List<Guid> listAccountId)
    {
        return await DbSet
            .Where(x => listAccountId.Contains((Guid)x.Id))
            .ToListAsync();
    }

    public async Task<bool> AccountNumberExists(int number)
    {
        // Kiểm tra xem số này đã tồn tại trong cơ sở dữ liệu hay chưa
        string formattedAccountNumber = number.ToString("D6");
        return await DbSet.AnyAsync(a => a.Code.EndsWith(formattedAccountNumber));
    }

    public async Task<Account?> GetAccountByCodeAsync(string code)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.Code == code && a.Status == AccountStatus.Active.ToString());
    }
}