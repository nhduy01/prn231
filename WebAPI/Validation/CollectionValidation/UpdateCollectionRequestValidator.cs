using Application.SendModels.Collection;
using FluentValidation;

namespace WebAPI.Validation.CollectionValidation;

public class UpdateCollectionRequestValidator : AbstractValidator<UpdateCollectionRequest>
{
    public UpdateCollectionRequestValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id không được để trống.")
            .NotEqual(Guid.Empty).WithMessage("Id không được là Guid.Empty.");

        RuleFor(c => c.CurrentUserId)
            .NotEmpty().WithMessage("CurrentUserId không được để trống.")
            .NotEqual(Guid.Empty).WithMessage("CurrentUserId không được là Guid.Empty.");
    }
}