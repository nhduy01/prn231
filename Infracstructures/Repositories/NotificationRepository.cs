using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(AppDbContext context) : base(context)
    {
    }
}