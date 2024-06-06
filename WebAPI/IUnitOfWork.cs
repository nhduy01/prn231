using WebAPI.Repositories;

namespace WebAPI
{
    public interface IUnitOfWork
    {
        public IAccountRepository AccountRepo { get; }

        public Task<int> SaveChangesAsync();
    }
}