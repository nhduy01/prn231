using Application.SendModels.Painting;
using FluentValidation;

namespace WebAPI.Validation.PaintingValidation;

public class RatingRequestValidator : AbstractValidator<RatingRequest>
{
    public RatingRequestValidator()
    {
        // Validate ScheduleId
        RuleFor(x => x.ScheduleId)
            .NotEmpty().WithMessage("ScheduleId is required.")
            .NotEqual(Guid.Empty).WithMessage("ScheduleId must be a valid GUID.");

        // Validate Paintings
        RuleFor(x => x.Paintings)
            .NotNull().WithMessage("Paintings list cannot be null.")
            .Must(paintings => paintings != null && paintings.Any()).WithMessage("Paintings list must contain at least one item.")
            .ForEach(painting => painting
                .NotEmpty().WithMessage("Each painting GUID must be a valid GUID.")
                .NotEqual(Guid.Empty).WithMessage("Each painting GUID must be a valid GUID."));
    }
}