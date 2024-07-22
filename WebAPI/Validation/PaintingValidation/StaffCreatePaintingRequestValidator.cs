using Application.SendModels.Painting;
using FluentValidation;

namespace WebAPI.Validation.PaintingValidation;

public class StaffCreatePaintingRequestValidator : AbstractValidator<StaffCreatePaintingRequest>
{
    public StaffCreatePaintingRequestValidator()
    {
        // Validate FullName
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("FullName is required.")
            .MaximumLength(100).WithMessage("FullName must be less than 100 characters.");

        // Validate Email
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.");

        // Validate Address
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(250).WithMessage("Address must be less than 250 characters.");

        // Validate Phone
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Phone must be a valid phone number (10-15 digits).");

        // Validate Birthday
        RuleFor(x => x.Birthday)
            .NotEmpty().WithMessage("Birthday is required.")
            .LessThan(DateTime.Today).WithMessage("Birthday must be in the past.");

        // Validate Image
        RuleFor(x => x.Image)
            .NotEmpty().WithMessage("Image is required.");

        // Validate Name (Painting)
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must be less than 100 characters.");

        // Validate Description (Painting)
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(250).WithMessage("Description must be less than 250 characters.");

        // Validate RoundTopicId
        RuleFor(x => x.RoundTopicId)
            .NotEmpty().WithMessage("RoundTopicId is required.")
            .NotEqual(Guid.Empty).WithMessage("RoundTopicId must be a valid GUID.");

        // Validate CurrentUserId
        RuleFor(x => x.CurrentUserId)
            .NotEmpty().WithMessage("CurrentUserId is required.")
            .NotEqual(Guid.Empty).WithMessage("CurrentUserId must be a valid GUID.");
    }
}