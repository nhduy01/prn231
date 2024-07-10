using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.Award;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class AwardValidator : IAwardValidator
    {
        private readonly IValidator<AwardRequest> _awardvalidator;
        private readonly IValidator<UpdateAwardRequest> _updateAwardvalidator;

        public AwardValidator(IValidator<AwardRequest> awardvalidator, IValidator<UpdateAwardRequest> updateAwardvalidator)
        {
            _awardvalidator = awardvalidator;
            _updateAwardvalidator = updateAwardvalidator;
        }

        public IValidator<AwardRequest> AwardCreateValidator => _awardvalidator;
        public IValidator<UpdateAwardRequest> UserAwardValidator => _updateAwardvalidator;
    }
}
