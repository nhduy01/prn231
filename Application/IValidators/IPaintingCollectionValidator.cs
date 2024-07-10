using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.PaintingCollection;
using FluentValidation;

namespace Application.IValidators
{
    public interface IPaintingCollectionValidator
    {
        IValidator<PaintingCollectionRequest> PaintingCollectionRequestValidator { get; }
    }
}
