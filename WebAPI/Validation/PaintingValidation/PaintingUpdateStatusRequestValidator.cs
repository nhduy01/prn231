using FluentValidation;
using Infracstructures.SendModels.Painting;

namespace WebAPI.Validation.PaintingValidation;

public class PaintingUpdateStatusRequestValidator : AbstractValidator<PaintingUpdateStatusRequest>
{
    public PaintingUpdateStatusRequestValidator()
    {
        // Validate Id
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .NotEqual(Guid.Empty).WithMessage("Id must be a valid GUID.");

        // Validate IsPassed
        RuleFor(x => x.IsPassed)
            .NotNull().WithMessage("IsPassed is required.");
    }
}