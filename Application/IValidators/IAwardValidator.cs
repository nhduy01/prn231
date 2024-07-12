using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Award;
using FluentValidation;

namespace Application.IValidators
{
    public interface IAwardValidator
    {
        public IValidator<AwardRequest> AwardRequestValidator { get; }
        public IValidator<UpdateAwardRequest> UpdateAwardRequestValidator {  get; }
    }
}
