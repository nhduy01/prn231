using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.Topic;
using FluentValidation;
using Infracstructures.SendModels.Sponsor;

namespace Infracstructures.Validators
{
    public class TopicValidator : ITopicValidator
    {
        private readonly IValidator<TopicRequest> _topicvalidator;
        private readonly IValidator<TopicUpdateRequest> _topicupdatevalidator;

        public TopicValidator(IValidator<TopicRequest> sponsorvalidator, IValidator<TopicUpdateRequest> sponsorupdatevalidator)
        {
            _topicvalidator = sponsorvalidator;
            _topicupdatevalidator = sponsorupdatevalidator;
        }

        public IValidator<TopicRequest> TopicRequestValidator => _topicvalidator;
        public IValidator<TopicUpdateRequest> TopicUpdateRequestValidator => _topicupdatevalidator;
    }
}
