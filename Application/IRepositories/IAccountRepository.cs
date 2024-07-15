using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.IRepositories;

public interface IAccountRepository : IGenericRepository<Account>
{
    Task<Account?> Login(string email);
    Task<Account?> GetByRefreshToken(string token);
    Task<bool> CheckDuplicateEmail(string email);
    Task<bool> CheckDuplicatePhone(string phone);
    Task<bool> CheckDuplicateUsername(string username);
    Task<bool> AccountNumberExists(int number);

    Task<List<Account>> GetAccountByListAccountId(List<Guid> listAccountId);

    Task<Account?> GetAccountByCodeAsync(string code);

    Task<int> CreateNumberOfAccountCode(string roleCode);


}