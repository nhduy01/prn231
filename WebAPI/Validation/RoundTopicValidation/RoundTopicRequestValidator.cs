using Application.SendModels.RoundTopic;
using FluentValidation;

namespace WebAPI.Validation.RoundTopicValidation;

public class RoundTopicRequestValidator : AbstractValidator<RoundTopicRequest>
{
    public RoundTopicRequestValidator()
    {
        // Validate RoundId
        RuleFor(x => x.RoundId)
            .NotEmpty().WithMessage("RoundId is required.")
            .NotEqual(Guid.Empty).WithMessage("RoundId must be a valid GUID.");

        // Validate ListTopicId
        RuleFor(x => x.ListTopicId)
            .NotNull().WithMessage("ListTopicId cannot be null.")
            .Must(list => list.All(id => id != Guid.Empty)).WithMessage("Each topic ID in ListTopicId must be a valid GUID.")
            .Must(list => list.Distinct().Count() == list.Count).WithMessage("ListTopicId cannot contain duplicate values.")
            .WithMessage("ListTopicId must contain at least one topic ID.");
    }
}