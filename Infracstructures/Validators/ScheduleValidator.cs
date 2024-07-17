using Application.IValidators;
using Application.SendModels.Schedule;
using FluentValidation;

namespace Infracstructures.Validators;

public class ScheduleValidator : IScheduleValidator
{
    public ScheduleValidator(IValidator<ScheduleRequest> schedulevalidator,
        IValidator<ScheduleUpdateRequest> scheduleupdatevalidator,
        IValidator<ScheduleForFinalRequest> scheduleforfinalvalidator)
    {
        ScheduleRequestValidator = schedulevalidator;
        ScheduleUpdateRequestValidator = scheduleupdatevalidator;
        ScheduleForFinalRequestValidator = scheduleforfinalvalidator;
    }

    public IValidator<ScheduleRequest> ScheduleRequestValidator { get; }

    public IValidator<ScheduleUpdateRequest> ScheduleUpdateRequestValidator { get; }

    public IValidator<ScheduleForFinalRequest> ScheduleForFinalRequestValidator { get; }
}