using Application.IRepositories;
using Domain.Models;
using WebAPI.IService.ICommonService;

namespace Infracstructures.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }

    }
}
