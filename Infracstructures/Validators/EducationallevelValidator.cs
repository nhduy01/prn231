using Application.IValidators;
using Application.SendModels.EducationalLevel;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class EducationalLevelValidator : IEducationalLevelValidator
    {
        private readonly IValidator<EducationalLevelRequest> _levelvalidator;
        private readonly IValidator<EducationalLevelUpdateRequest> _updatelevelvalidator;

        public EducationalLevelValidator(IValidator<EducationalLevelRequest> levelvalidator, IValidator<EducationalLevelUpdateRequest> updatelevelvalidator)
        {
            _levelvalidator = levelvalidator;
            _updatelevelvalidator = updatelevelvalidator;
        }

        public IValidator<EducationalLevelRequest> EducationalLevelRequestValidator => _levelvalidator;
        public IValidator<EducationalLevelUpdateRequest> EducationalLevelUpdateRequestValidator => _updatelevelvalidator;
    }
}
