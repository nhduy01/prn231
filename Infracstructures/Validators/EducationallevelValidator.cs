using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.Contest;
using Application.SendModels.EducationalLevel;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class EducationallevelValidator : IEducationalLevelValidator
    {
        private readonly IValidator<EducationalLevelRequest> _levelvalidator;
        private readonly IValidator<EducationalLevelUpdateRequest> _updatelevelvalidator;

        public EducationallevelValidator(IValidator<EducationalLevelRequest> levelvalidator, IValidator<EducationalLevelUpdateRequest> updatelevelvalidator)
        {
            _levelvalidator = levelvalidator;
            _updatelevelvalidator = updatelevelvalidator;
        }

        public IValidator<EducationalLevelRequest> EducationalLevelRequestValidator => _levelvalidator;
        public IValidator<EducationalLevelUpdateRequest> EducationalLevelUpdateRequestValidator => _updatelevelvalidator;
    }
}
