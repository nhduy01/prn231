using Application.IValidators;
using Application.SendModels.Round;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class RoundValidator : IRoundValidator
    {
        private readonly IValidator<RoundRequest> _roundvalidator;
        private readonly IValidator<RoundUpdateRequest> _updateroundtvalidator;
        private readonly IValidator<DeleteRoundRequest> _deleteoundtvalidator;

        public RoundValidator(IValidator<RoundRequest> roundvalidator, IValidator<RoundUpdateRequest> updateroundvalidator, IValidator<DeleteRoundRequest> deleteoundtvalidator)
        {
            _roundvalidator = roundvalidator;
            _updateroundtvalidator = updateroundvalidator;
            _deleteoundtvalidator = deleteoundtvalidator;
        }

        public IValidator<RoundRequest> RoundRequestValidator => _roundvalidator;
        public IValidator<RoundUpdateRequest> RoundUpdateRequestValidator => _updateroundtvalidator;
        public IValidator<DeleteRoundRequest> DeleteRoundRequestValidator => _deleteoundtvalidator;
    }
}
