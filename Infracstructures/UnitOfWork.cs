using Application;
using Application.Repositories;
using Infracstructures.Repositories;

namespace Infracstructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IAccountRepository _accountRepository;


        public UnitOfWork(AppDbContext context, IAccountRepository accountRepository)
            
        {
            _context = context;
            _accountRepository = accountRepository;
            
        }

        public IAccountRepository AccountRepo => _accountRepository;
       
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}