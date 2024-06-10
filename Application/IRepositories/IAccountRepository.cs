using Domain.Models;

namespace Application.IRepositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public Task<Account?> Login(string email);
    }
}