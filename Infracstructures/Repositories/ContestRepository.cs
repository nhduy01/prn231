using Domain.Models;
using Application.IRepositories;
using WebAPI.IService.ICommonService;
using Application.ViewModels.ContestViewModels;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories
{
    public class ContestRepository : GenericRepository<Contest>, IContestRepository
    {
        public ContestRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            
        }
        
        /*public async Task<ContestViewModel> GetAllContestInformation(Guid contestId)
        {

            return await _dbSet.Include(x => x.EducationalLevel)
                .ThenInclude(x => x.Round)
                .Include(x => x.EducationalLevel);
        }*/
        
    }
}
