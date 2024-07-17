using Application.SendModels.Notification;
using FluentValidation;

namespace Application.IValidators;

public interface INotificationValidator
{
    IValidator<NotificationRequest> NotificationRequestValidator { get; }
}