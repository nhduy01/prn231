using Application.IValidators;
using Application.SendModels.Resources;
using FluentValidation;

namespace Infracstructures.Validators;

public class ResourceValidator : IResourceValidator
{
    public ResourceValidator(IValidator<ResourcesRequest> resourcevalidator,
        IValidator<ResourcesUpdateRequest> updateresourcevalidator)
    {
        ResourcesRequestValidator = resourcevalidator;
        ResourcesUpdateRequestValidator = updateresourcevalidator;
    }

    public IValidator<ResourcesRequest> ResourcesRequestValidator { get; }

    public IValidator<ResourcesUpdateRequest> ResourcesUpdateRequestValidator { get; }
}