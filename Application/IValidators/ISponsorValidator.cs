using FluentValidation;
using Infracstructures.SendModels.Sponsor;

namespace Application.IValidators;

public interface ISponsorValidator
{
    IValidator<SponsorRequest> SponsorRequestValidator { get; }
    IValidator<SponsorUpdateRequest> SponsorUpdateRequestValidator { get; }
}