using Application.IValidators;
using Application.SendModels.Collection;
using FluentValidation;

namespace Infracstructures.Validators;

public class CollectionValidator : ICollectionValidator
{
    public CollectionValidator(IValidator<CollectionRequest> collectionvalidator,
        IValidator<UpdateCollectionRequest> updatecollectionvalidator)
    {
        CollectionRequestValidator = collectionvalidator;
        UpdateCollectionRequestValidator = updatecollectionvalidator;
    }

    public IValidator<CollectionRequest> CollectionRequestValidator { get; }

    public IValidator<UpdateCollectionRequest> UpdateCollectionRequestValidator { get; }
}