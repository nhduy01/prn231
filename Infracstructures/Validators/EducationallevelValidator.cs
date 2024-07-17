using Application.IValidators;
using Application.SendModels.EducationalLevel;
using FluentValidation;

namespace Infracstructures.Validators;

public class EducationalLevelValidator : IEducationalLevelValidator
{
    public EducationalLevelValidator(IValidator<EducationalLevelRequest> levelvalidator,
        IValidator<EducationalLevelUpdateRequest> updatelevelvalidator)
    {
        EducationalLevelRequestValidator = levelvalidator;
        EducationalLevelUpdateRequestValidator = updatelevelvalidator;
    }

    public IValidator<EducationalLevelRequest> EducationalLevelRequestValidator { get; }

    public IValidator<EducationalLevelUpdateRequest> EducationalLevelUpdateRequestValidator { get; }
}