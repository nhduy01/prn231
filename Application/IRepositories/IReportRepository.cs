using Domain.Models;

namespace Application.IRepositories;

public interface IReportRepository : IGenericRepository<Report>
{
    Task<List<Report>> GetAllReportPendingAsync();
}