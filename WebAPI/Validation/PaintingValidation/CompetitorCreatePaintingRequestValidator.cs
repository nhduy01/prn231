using Application.SendModels.Painting;
using FluentValidation;

namespace WebAPI.Validation.PaintingValidation;

public class CompetitorCreatePaintingRequestValidator : AbstractValidator<CompetitorCreatePaintingRequest>
{
    public CompetitorCreatePaintingRequestValidator()
    {
        // Validate AccountId
        RuleFor(x => x.AccountId)
            .NotEmpty().WithMessage("AccountId is required.")
            .NotEqual(Guid.Empty).WithMessage("AccountId must be a valid GUID.");

        // Validate Image
        RuleFor(x => x.Image)
            .NotEmpty().WithMessage("Image is required.");

        // Validate Name
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must be less than 100 characters.");

        // Validate Description
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(250).WithMessage("Description must be less than 250 characters.");

        // Validate RoundTopicId
        RuleFor(x => x.RoundTopicId)
            .NotEmpty().WithMessage("RoundTopicId is required.")
            .NotEqual(Guid.Empty).WithMessage("RoundTopicId must be a valid GUID.");
    }
}