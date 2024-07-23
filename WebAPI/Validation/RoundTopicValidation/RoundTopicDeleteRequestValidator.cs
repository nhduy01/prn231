using Application.SendModels.RoundTopic;
using FluentValidation;

namespace WebAPI.Validation.RoundTopicValidation;

public class RoundTopicDeleteRequestValidator : AbstractValidator<RoundTopicDeleteRequest>
{
    public RoundTopicDeleteRequestValidator()
    {
        // Validate RoundId
        RuleFor(x => x.RoundId)
            .NotEmpty().WithMessage("RoundId is required.")
            .NotEqual(Guid.Empty).WithMessage("RoundId must be a valid GUID.");

        // Validate TopicId
        RuleFor(x => x.TopicId)
            .NotEmpty().WithMessage("TopicId is required.")
            .NotEqual(Guid.Empty).WithMessage("TopicId must be a valid GUID.");
    }
}