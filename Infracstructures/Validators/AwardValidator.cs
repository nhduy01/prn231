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

        public IValidator<AwardRequest> AwardRequestValidator => _awardvalidator;
        public IValidator<UpdateAwardRequest> UpdateAwardRequestValidator => _updateAwardvalidator;
    }
}
