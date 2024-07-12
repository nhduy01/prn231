using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.Round;
using Application.SendModels.Schedule;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class ScheduleValidator : IScheduleValidator
    {
        private readonly IValidator<ScheduleForFinalRequest> _scheduleforfinalvalidator;
        private readonly IValidator<ScheduleUpdateRequest> _scheduleupdatevalidator;
        private readonly IValidator<ScheduleRequest> _schedulevalidator;

        public ScheduleValidator(IValidator<ScheduleRequest> schedulevalidator, IValidator<ScheduleUpdateRequest> scheduleupdatevalidator, IValidator<ScheduleForFinalRequest> scheduleforfinalvalidator)
        {
            _schedulevalidator = schedulevalidator;
            _scheduleupdatevalidator = scheduleupdatevalidator;
            _scheduleforfinalvalidator = scheduleforfinalvalidator;
        }

        public IValidator<ScheduleRequest> ScheduleRequestValidator => _schedulevalidator;
        public IValidator<ScheduleUpdateRequest> ScheduleUpdateRequestValidator => _scheduleupdatevalidator;
        public IValidator<ScheduleForFinalRequest> ScheduleForFinalRequestValidator => _scheduleforfinalvalidator;
    }
}
