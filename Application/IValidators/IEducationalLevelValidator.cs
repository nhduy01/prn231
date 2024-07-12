using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.EducationalLevel;
using FluentValidation;

namespace Application.IValidators
{
    public interface IEducationalLevelValidator
    {
        IValidator<EducationalLevelRequest> EducationalLevelRequestValidator { get; }
        IValidator<EducationalLevelUpdateRequest> EducationalLevelUpdateRequestValidator { get; }
    }
}
