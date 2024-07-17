using Application.IValidators;
using FluentValidation;
using Infracstructures.SendModels.Sponsor;

namespace Infracstructures.Validators;

public class SponsorValidator : ISponsorValidator
{
    public SponsorValidator(IValidator<SponsorRequest> sponsorvalidator,
        IValidator<SponsorUpdateRequest> sponsorupdatevalidator)
    {
        SponsorRequestValidator = sponsorvalidator;
        SponsorUpdateRequestValidator = sponsorupdatevalidator;
    }

    public IValidator<SponsorRequest> SponsorRequestValidator { get; }

    public IValidator<SponsorUpdateRequest> SponsorUpdateRequestValidator { get; }
}