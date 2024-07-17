using Application.IValidators;
using Application.SendModels.RoundTopic;
using FluentValidation;

namespace Infracstructures.Validators;

public class RoundTopicValidator : IRoundTopicValidator
{
    public RoundTopicValidator(IValidator<RoundTopicRequest> roundtopicvalidator,
        IValidator<RoundTopicDeleteRequest> roundtopicdeletevalidator)
    {
        RoundTopicRequestValidator = roundtopicvalidator;
        RoundTopicDeleteRequestValidator = roundtopicdeletevalidator;
    }

    public IValidator<RoundTopicRequest> RoundTopicRequestValidator { get; }

    public IValidator<RoundTopicDeleteRequest> RoundTopicDeleteRequestValidator { get; }
}