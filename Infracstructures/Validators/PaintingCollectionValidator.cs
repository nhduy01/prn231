using Application.IValidators;
using Application.SendModels.PaintingCollection;
using FluentValidation;

namespace Infracstructures.Validators;

public class PaintingCollectionValidator : IPaintingCollectionValidator
{
    public PaintingCollectionValidator(IValidator<PaintingCollectionRequest> paintingcollectionvalidator)
    {
        PaintingCollectionRequestValidator = paintingcollectionvalidator;
    }

    public IValidator<PaintingCollectionRequest> PaintingCollectionRequestValidator { get; }
}