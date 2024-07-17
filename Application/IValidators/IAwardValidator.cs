using Application.SendModels.Award;
using FluentValidation;

namespace Application.IValidators;

public interface IAwardValidator
{
    public IValidator<AwardRequest> AwardRequestValidator { get; }
    public IValidator<UpdateAwardRequest> UpdateAwardRequestValidator { get; }
}