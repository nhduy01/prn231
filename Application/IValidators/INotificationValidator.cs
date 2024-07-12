using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Notification;
using FluentValidation;

namespace Application.IValidators
{
    public interface INotificationValidator
    {
        IValidator<NotificationRequest> NotificationRequestValidator { get; }
    }
}
