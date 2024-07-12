using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Topic;
using FluentValidation;

namespace Application.IValidators
{
    public interface ITopicValidator
    {
        IValidator<TopicRequest> TopicRequestValidator { get; }
        IValidator<TopicUpdateRequest> TopicUpdateRequestValidator { get; }
    }
}
