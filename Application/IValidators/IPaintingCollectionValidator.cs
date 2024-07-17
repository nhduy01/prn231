using Application.SendModels.PaintingCollection;
using FluentValidation;

namespace Application.IValidators;

public interface IPaintingCollectionValidator
{
    IValidator<PaintingCollectionRequest> PaintingCollectionRequestValidator { get; }
}