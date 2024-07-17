using Application.IValidators;
using Application.SendModels.Award;
using FluentValidation;

namespace Infracstructures.Validators;

public class AwardValidator : IAwardValidator
{
    public AwardValidator(IValidator<AwardRequest> awardvalidator, IValidator<UpdateAwardRequest> updateAwardvalidator)
    {
        AwardRequestValidator = awardvalidator;
        UpdateAwardRequestValidator = updateAwardvalidator;
    }

    public IValidator<AwardRequest> AwardRequestValidator { get; }

    public IValidator<UpdateAwardRequest> UpdateAwardRequestValidator { get; }
}