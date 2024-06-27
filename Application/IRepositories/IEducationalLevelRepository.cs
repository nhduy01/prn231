using Domain.Models;

namespace Application.IRepositories;

public interface IEducationalLevelRepository : IGenericRepository<EducationalLevel>
{
    Task<bool> CheckValidRoundDate(Guid EducationalLevelId, DateTime RoundStartTime, DateTime RoundEndTime);
}