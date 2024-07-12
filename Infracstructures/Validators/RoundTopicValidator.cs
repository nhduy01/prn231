using Application.IValidators;
using Application.SendModels.RoundTopic;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class RoundTopicValidator : IRoundTopicValidator
    {
        private readonly IValidator<RoundTopicRequest> _roundtopicvalidator;

        public RoundTopicValidator(IValidator<RoundTopicRequest> roundtopicvalidator)
        {
            _roundtopicvalidator = roundtopicvalidator;
        }

        public IValidator<RoundTopicRequest> RoundTopicRequestValidator => _roundtopicvalidator;
    }
}
