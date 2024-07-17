using Application.IValidators;
using Application.SendModels.Notification;
using FluentValidation;

namespace Infracstructures.Validators;

public class NotificationValidator : INotificationValidator
{
    public NotificationValidator(IValidator<NotificationRequest> notificationvalidator)
    {
        NotificationRequestValidator = notificationvalidator;
    }

    public IValidator<NotificationRequest> NotificationRequestValidator { get; }
}