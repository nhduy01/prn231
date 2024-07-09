using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.IRepositories;

public interface IAccountRepository : IGenericRepository<Account>
{
    public Task<Account?> Login(string email);
    public Task<Account?> GetByRefreshToken(string token);
    Task<bool> CheckDuplicateEmail(string email);
    Task<bool> CheckDuplicatePhone(string phone);
    Task<bool> CheckDuplicateUsername(string username);

    Task<List<Account>> GetAccountByListAccountId(List<Guid> listAccountId);


}