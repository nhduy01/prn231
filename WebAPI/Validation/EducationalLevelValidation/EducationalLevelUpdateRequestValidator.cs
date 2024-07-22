using Application.SendModels.EducationalLevel;
using FluentValidation;

namespace WebAPI.Validation.EducationalLevelValidation;

public class EducationalLevelUpdateRequestValidator : AbstractValidator<EducationalLevelUpdateRequest>
{
    public EducationalLevelUpdateRequestValidator()
    {
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