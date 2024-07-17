using Application.SendModels.Topic;
using FluentValidation;

namespace WebAPI.Validation.TopicValidation;

public class TopicUpdateRequestValidator : AbstractValidator<TopicUpdateRequest>
{
    public TopicUpdateRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Role name is required.")
            .Length(2, 50).WithMessage("Role name must be between 2 and 50 characters.");

        RuleFor(x => x.CurrentUserId)
            .NotEmpty()
            .WithMessage("CurrentUserId is required.");
    }
}