using Application.SendModels.Round;
using FluentValidation;

namespace WebAPI.Validation.RoundValidation;

public class RoundUpdateRequestValidator : AbstractValidator<RoundUpdateRequest>
{
    public RoundUpdateRequestValidator()
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