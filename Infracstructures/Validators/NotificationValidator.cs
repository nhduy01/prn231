﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.EducationalLevel;
using Application.SendModels.Notification;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class NotificationValidator : INotificationValidator
    {
        private readonly IValidator<NotificationRequest> _notificationvalidator;

        public NotificationValidator(IValidator<NotificationRequest> notificationvalidator)
        {
            _notificationvalidator = notificationvalidator;
        }

        public IValidator<NotificationRequest> NotificationRequestValidator => _notificationvalidator;
    }
}
