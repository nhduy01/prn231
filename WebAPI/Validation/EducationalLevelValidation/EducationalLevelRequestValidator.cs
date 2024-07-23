using Application.SendModels.EducationalLevel;
using FluentValidation;

namespace WebAPI.Validation.EducationalLevelValidation;

public class EducationalLevelRequestValidator : AbstractValidator<EducationalLevelRequest>
{
    public EducationalLevelRequestValidator()
    {
        // Validate Level
        RuleFor(x => x.Level)
            .NotEmpty().WithMessage("Level is required.")
            .Length(1, 50).WithMessage("Level must be between 1 and 50 characters.");

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