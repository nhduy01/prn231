using Application.SendModels.Topic;
using FluentValidation;

namespace Application.IValidators;

public interface ITopicValidator
{
    IValidator<TopicRequest> TopicRequestValidator { get; }
    IValidator<TopicUpdateRequest> TopicUpdateRequestValidator { get; }
}