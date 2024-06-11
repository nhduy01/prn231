using Domain.Models;

namespace Application.IRepositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public Task<Account?> Login(string email);
        public Task<Account?> GetByRefreshToken(string token);
        public Task<bool> CheckDuplicate(string email, string phone);
    }
}