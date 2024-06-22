using Domain.Models;

namespace Application.IRepositories;

public interface IScheduleRepository : IGenericRepository<Schedule>
{
    public Task<Schedule?> GetById(Guid id);
}