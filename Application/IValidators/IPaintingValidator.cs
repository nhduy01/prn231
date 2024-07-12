using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Painting;
using FluentValidation;
using Infracstructures.SendModels.Painting;

namespace Application.IValidators
{
    public interface IPaintingValidator
    {
        IValidator<PaintingRequest> PaintingRequestValidator { get; }
        IValidator<PaintingRequest2> PaintingRequest2Validator { get; }
        IValidator<PaintingUpdateStatusRequest> PaintingUpdateStatusRequestValidator { get; }
        IValidator<RatingRequest> RatingRequestValidator { get; }
        IValidator<UpdatePaintingRequest> UpdatePaintingRequestValidator { get; }
    }
}
