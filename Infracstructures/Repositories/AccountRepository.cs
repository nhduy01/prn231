using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.IService.ICommonService;

namespace Infracstructures.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        
        public AccountRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }

        public async Task<Account?> Login(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Email == email);
        }
    }
}
