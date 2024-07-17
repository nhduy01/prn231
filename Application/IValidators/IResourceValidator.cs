using Application.SendModels.Resources;
using FluentValidation;

namespace Application.IValidators;

public interface IResourceValidator
{
    IValidator<ResourcesRequest> ResourcesRequestValidator { get; }
    IValidator<ResourcesUpdateRequest> ResourcesUpdateRequestValidator { get; }
}