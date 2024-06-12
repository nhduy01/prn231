using Application.IRepositories;
using Application.IService.ICommonService;
using Domain.Models;

namespace Infracstructures.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(
        context, timeService, claimsService)
    {
    }
}