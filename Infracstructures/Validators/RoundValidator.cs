using Application.IValidators;
using Application.SendModels.Round;
using FluentValidation;

namespace Infracstructures.Validators;

public class RoundValidator : IRoundValidator
{
    public RoundValidator(IValidator<RoundRequest> roundvalidator, IValidator<RoundUpdateRequest> updateroundvalidator)
    {
        RoundRequestValidator = roundvalidator;
        RoundUpdateRequestValidator = updateroundvalidator;
    }

    public IValidator<RoundRequest> RoundRequestValidator { get; }

    public IValidator<RoundUpdateRequest> RoundUpdateRequestValidator { get; }
}