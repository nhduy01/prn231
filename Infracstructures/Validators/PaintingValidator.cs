using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.PaintingCollection;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class PaintingValidator : IPaintingValidator
    {
        private readonly IValidator<PaintingCollectionRequest> _paintingvalidator;

        public PaintingValidator(IValidator<PaintingCollectionRequest> paintingcollectionvalidator)
        {
            _paintingvalidator = paintingcollectionvalidator;
        }

        public IValidator<PaintingCollectionRequest> PaintingCollectionRequestValidator => _paintingvalidator;
    }
}
