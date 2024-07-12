using Application.SendModels.RoundTopic;
using FluentValidation;

namespace Application.IValidators
{
    public interface IRoundTopicValidator
    {
        IValidator<RoundTopicRequest> RoundTopicRequestValidator { get; }
    }
}
