using Domain.Models;

namespace Application.IRepositories;

public interface IRoundRepository : IGenericRepository<Round>
{
    Task<Round> GetTopic(Guid RoundId);
}