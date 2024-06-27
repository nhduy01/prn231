using Domain.Models;

namespace Application.IRepositories;

public interface IRoundRepository : IGenericRepository<Round>
{
    public Task<Round?> GetRoundDetail(Guid id);
    Task<Round?> GetTopic(Guid RoundId);

    Task<bool> CheckSubmitValidDate(Guid RoundId);
}