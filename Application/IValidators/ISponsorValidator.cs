using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infracstructures.SendModels.Sponsor;

namespace Application.IValidators
{
    public interface ISponsorValidator
    {
        IValidator<SponsorRequest> SponsorRequestValidator { get; }
        IValidator<SponsorUpdateRequest> SponsorUpdateRequestValidator { get; }
    }
}
