using Application.IValidators;
using Application.SendModels.PaintingCollection;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class PaintingCollectionValidator : IPaintingCollectionValidator
    {
        private readonly IValidator<PaintingCollectionRequest> _paintingcollectionvalidator;

        public PaintingCollectionValidator(IValidator<PaintingCollectionRequest> paintingcollectionvalidator)
        {
            _paintingcollectionvalidator = paintingcollectionvalidator;
        }

        public IValidator<PaintingCollectionRequest> PaintingCollectionRequestValidator => _paintingcollectionvalidator;
    }
}
