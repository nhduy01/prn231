using Application.SendModels.Resources;
using FluentValidation;

namespace WebAPI.Validation.ResourceValidation;

public class ResourcesUpdateRequestValidator : AbstractValidator<ResourcesUpdateRequest>
{
    public ResourcesUpdateRequestValidator()
    {
        // Validate Id
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .NotEqual(Guid.Empty).WithMessage("Id must be a valid GUID.");

        // Validate Sponsorship
        RuleFor(x => x.Sponsorship)
            .MaximumLength(200).WithMessage("Sponsorship must be less than 200 characters.");

        // Validate CurrentUserId
        RuleFor(x => x.CurrentUserId)
            .NotEmpty().WithMessage("CurrentUserId is required.")
            .NotEqual(Guid.Empty).WithMessage("CurrentUserId must be a valid GUID.");
    }
}