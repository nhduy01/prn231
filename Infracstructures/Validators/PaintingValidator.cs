using Application.IValidators;
using Application.SendModels.Painting;
using FluentValidation;
using Infracstructures.SendModels.Painting;

namespace Infracstructures.Validators;

public class PaintingValidator : IPaintingValidator
{
    public PaintingValidator(IValidator<PaintingRequest> paintingvalidator,
        IValidator<PaintingRequest2> painting2validator,
        IValidator<PaintingUpdateStatusRequest> paintingupdatestatusvalidator,
        IValidator<RatingRequest> ratingvalidator,
        IValidator<UpdatePaintingRequest> updatepaintingvalidator,
        IValidator<FilterPaintingRequest> filterpaintingvalidator)
    {
        PaintingRequestValidator = paintingvalidator;
        PaintingRequest2Validator = painting2validator;
        PaintingUpdateStatusRequestValidator = paintingupdatestatusvalidator;
        RatingRequestValidator = ratingvalidator;
        UpdatePaintingRequestValidator = updatepaintingvalidator;
        FilterPaintingRequestValidator = filterpaintingvalidator;
    }

    public IValidator<PaintingRequest> PaintingRequestValidator { get; }

    public IValidator<PaintingRequest2> PaintingRequest2Validator { get; }

    public IValidator<PaintingUpdateStatusRequest> PaintingUpdateStatusRequestValidator { get; }

    public IValidator<RatingRequest> RatingRequestValidator { get; }

    public IValidator<UpdatePaintingRequest> UpdatePaintingRequestValidator { get; }

    public IValidator<FilterPaintingRequest> FilterPaintingRequestValidator { get; }
}