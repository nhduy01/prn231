using Application.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public IAccountRepository AccountRepo { get; }

        public Task<int> SaveChangesAsync();
    }
}