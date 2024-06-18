using Application.BaseModels;
using Application.SendModels.Notification;
using Infracstructures.ViewModels.NotificationViewModels;

namespace Application.IService;

public interface INotificationService
{
    public Task<Guid?> CreateNotification(NotificationRequest Notification);
    public Task<List<NotificationViewModel>> Get5Notification(Guid id);
    public Task<NotificationDetailViewModel?> GetNotificationById(Guid id);
    
    public Task<bool?> ReadNotification(Guid id);

}