﻿using Domain.Models;

namespace Application.IRepositories;

public interface IRoundRepository : IGenericRepository<Round>
{
    public Task<Round?> GetRoundDetail(Guid id);
    Task<List<Topic>> GetTopic(Guid RoundId);
    Task<List<Round>> GetRoundByLevelId(Guid levelId);
    Task<bool> CheckSubmitValidDate(Guid RoundId);
    Task<List<Round>> GetRoundsByNameInContest(Guid contestId, string roundName);
}