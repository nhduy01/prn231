using Application.SendModels.Schedule;
using FluentValidation;

namespace WebAPI.Validation.ScheduleValidation;

public class ScheduleUpdateRequestValidator : AbstractValidator<ScheduleUpdateRequest>
{
    public ScheduleUpdateRequestValidator()
    {
        // Validate Id
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .NotEqual(Guid.Empty).WithMessage("Id must be a valid GUID.");

        // Validate CurrentUserId
        RuleFor(x => x.CurrentUserId)
            .NotEmpty().WithMessage("CurrentUserId is required.")
            .NotEqual(Guid.Empty).WithMessage("CurrentUserId must be a valid GUID.");
    }
}