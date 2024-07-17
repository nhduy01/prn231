using Application.SendModels.EducationalLevel;
using FluentValidation;

namespace Application.IValidators;

public interface IEducationalLevelValidator
{
    IValidator<EducationalLevelRequest> EducationalLevelRequestValidator { get; }
    IValidator<EducationalLevelUpdateRequest> EducationalLevelUpdateRequestValidator { get; }
}