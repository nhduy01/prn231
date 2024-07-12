using Application.IValidators;
using Application.SendModels.Contest;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class ContestValidator : IContestValidator
    {
        private readonly IValidator<ContestRequest> _contestvalidator;
        private readonly IValidator<UpdateContest> _updatecontestvalidator;

        public ContestValidator(IValidator<ContestRequest> contestvalidator, IValidator<UpdateContest> updatecontestvalidator)
        {
            _contestvalidator = contestvalidator;
            _updatecontestvalidator = updatecontestvalidator;
        }

        public IValidator<ContestRequest> ContestRequestValidator => _contestvalidator;
        public IValidator<UpdateContest> UpdateContestValidator => _updatecontestvalidator;
    }
}
