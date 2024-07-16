using Application.IValidators;
using Application.SendModels.RoundTopic;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class RoundTopicValidator : IRoundTopicValidator
    {
        private readonly IValidator<RoundTopicRequest> _roundtopicvalidator;
        private readonly IValidator<RoundTopicDeleteRequest> _roundtopicdeletevalidator;

        public RoundTopicValidator(IValidator<RoundTopicRequest> roundtopicvalidator, IValidator<RoundTopicDeleteRequest> roundtopicdeletevalidator)
        {
            _roundtopicvalidator = roundtopicvalidator;
            _roundtopicdeletevalidator = roundtopicdeletevalidator;
        }

        public IValidator<RoundTopicRequest> RoundTopicRequestValidator => _roundtopicvalidator;
        public IValidator<RoundTopicDeleteRequest> RoundTopicDeleteRequestValidator => _roundtopicdeletevalidator;
    }
}
