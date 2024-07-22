using Application.SendModels.Painting;
using FluentValidation;

namespace WebAPI.Validation.PaintingValidation;

public class UpdatePaintingRequestValidator : AbstractValidator<UpdatePaintingRequest>
{
    public UpdatePaintingRequestValidator()
    {
        // Validate Id
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .NotEqual(Guid.Empty).WithMessage("Id must be a valid GUID.");

        // Validate AwardId
        RuleFor(x => x.AwardId)
            .NotEqual(Guid.Empty).When(x => x.AwardId.HasValue).WithMessage("AwardId must be a valid GUID.");

        // Validate RoundTopicId
        RuleFor(x => x.RoundTopicId)
            .NotEqual(Guid.Empty).When(x => x.RoundTopicId.HasValue).WithMessage("RoundTopicId must be a valid GUID.");

        // Validate AccountId
        RuleFor(x => x.AccountId)
            .NotEqual(Guid.Empty).When(x => x.AccountId.HasValue).WithMessage("AccountId must be a valid GUID.");

        // Validate ScheduleId
        RuleFor(x => x.ScheduleId)
            .NotEqual(Guid.Empty).When(x => x.ScheduleId.HasValue).WithMessage("ScheduleId must be a valid GUID.");

        // Validate Code
        RuleFor(x => x.Code)
            .MaximumLength(50).WithMessage("Code must be less than 50 characters.");

        // Validate CurrentUserId
        RuleFor(x => x.CurrentUserId)
            .NotEmpty().WithMessage("CurrentUserId is required.")
            .NotEqual(Guid.Empty).WithMessage("CurrentUserId must be a valid GUID.");
    }
}