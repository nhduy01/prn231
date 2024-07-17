using Application.IValidators;
using Application.SendModels.Topic;
using FluentValidation;

namespace Infracstructures.Validators;

public class TopicValidator : ITopicValidator
{
    public TopicValidator(IValidator<TopicRequest> sponsorvalidator,
        IValidator<TopicUpdateRequest> sponsorupdatevalidator)
    {
        TopicRequestValidator = sponsorvalidator;
        TopicUpdateRequestValidator = sponsorupdatevalidator;
    }

    public IValidator<TopicRequest> TopicRequestValidator { get; }

    public IValidator<TopicUpdateRequest> TopicUpdateRequestValidator { get; }
}