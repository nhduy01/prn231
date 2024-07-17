using Application.SendModels.Award;
using FluentValidation;

namespace WebAPI.Validation.AwardValidation;

public class UpdateAwardRequestValidator : AbstractValidator<UpdateAwardRequest>
{
    public UpdateAwardRequestValidator()
    {
        RuleFor(user => user.Id).NotEmpty().WithMessage("Id không được để trống.");
    }
}