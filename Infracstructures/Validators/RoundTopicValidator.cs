using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;
using Application.IValidators;
using Application.SendModels.PaintingCollection;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class RoundTopicValidator : IRoundTopicValidator
    {
        private readonly IValidator<RoundTopicValidator> _roundtopicvalidator;

        public RoundTopicValidator(IValidator<RoundTopicValidator> roundtopicvalidator)
        {
            _roundtopicvalidator = roundtopicvalidator;
        }

        public IValidator<RoundTopicValidator> RoundTopicValidatorValidator => _roundtopicvalidator;
    }
}
