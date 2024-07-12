using Application.IValidators;
using Application.SendModels.Round;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class RoundValidator : IRoundValidator
    {
        private readonly IValidator<RoundRequest> _roundvalidator;
        private readonly IValidator<RoundUpdateRequest> _updateroundtvalidator;

        public RoundValidator(IValidator<RoundRequest> roundvalidator, IValidator<RoundUpdateRequest> updateroundvalidator)
        {
            _roundvalidator = roundvalidator;
            _updateroundtvalidator = updateroundvalidator;
        }

        public IValidator<RoundRequest> RoundRequestValidator => _roundvalidator;
        public IValidator<RoundUpdateRequest> RoundUpdateRequestValidator => _updateroundtvalidator;
    }
}
