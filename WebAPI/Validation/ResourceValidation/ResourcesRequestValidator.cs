using Application.SendModels.Resources;
using FluentValidation;

namespace WebAPI.Validation.ResourceValidation;

public class ResourcesRequestValidator : AbstractValidator<ResourcesRequest>
{
    public ResourcesRequestValidator()
    {
        // Validate Sponsorship
        RuleFor(x => x.Sponsorship)
            .NotEmpty().WithMessage("Sponsorship is required.")
            .MaximumLength(200).WithMessage("Sponsorship must be less than 200 characters.");

        // Validate SponsorId
        RuleFor(x => x.SponsorId)
            .NotEmpty().WithMessage("SponsorId is required.")
            .NotEqual(Guid.Empty).WithMessage("SponsorId must be a valid GUID.");

        // Validate ContestId
        RuleFor(x => x.ContestId)
            .NotEmpty().WithMessage("ContestId is required.")
            .NotEqual(Guid.Empty).WithMessage("ContestId must be a valid GUID.");

        // Validate CurrentUserId
        RuleFor(x => x.CurrentUserId)
            .NotEmpty().WithMessage("CurrentUserId is required.")
            .NotEqual(Guid.Empty).WithMessage("CurrentUserId must be a valid GUID.");
    }
}