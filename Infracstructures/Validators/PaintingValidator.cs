using Application.IValidators;
using Application.SendModels.Painting;
using FluentValidation;
using Infracstructures.SendModels.Painting;

namespace Infracstructures.Validators
{
    public class PaintingValidator : IPaintingValidator
    {
        private readonly IValidator<PaintingRequest> _paintingvalidator;
        private readonly IValidator<PaintingRequest2> _painting2validator;
        private readonly IValidator<PaintingUpdateStatusRequest> _paintingupdatestatusvalidator;
        private readonly IValidator<RatingRequest> _ratingvalidator;
        private readonly IValidator<UpdatePaintingRequest> _updatepaintingvalidator;
        private readonly IValidator<FilterPaintingRequest> _filterpaintingvalidator;

        public PaintingValidator(IValidator<PaintingRequest> paintingvalidator,
                                    IValidator<PaintingRequest2> painting2validator,
                                    IValidator<PaintingUpdateStatusRequest> paintingupdatestatusvalidator,
                                    IValidator<RatingRequest> ratingvalidator,
                                    IValidator<UpdatePaintingRequest> updatepaintingvalidator,
                                    IValidator<FilterPaintingRequest> filterpaintingvalidator)
        {
            _paintingvalidator = paintingvalidator;
            _painting2validator = painting2validator;
            _paintingupdatestatusvalidator = paintingupdatestatusvalidator;
            _ratingvalidator = ratingvalidator;
            _updatepaintingvalidator = updatepaintingvalidator;
            _filterpaintingvalidator = filterpaintingvalidator;
        }

        public IValidator<PaintingRequest> PaintingRequestValidator => _paintingvalidator;
        public IValidator<PaintingRequest2> PaintingRequest2Validator => _painting2validator;
        public IValidator<PaintingUpdateStatusRequest> PaintingUpdateStatusRequestValidator => _paintingupdatestatusvalidator;
        public IValidator<RatingRequest> RatingRequestValidator => _ratingvalidator;
        public IValidator<UpdatePaintingRequest> UpdatePaintingRequestValidator => _updatepaintingvalidator;
        public IValidator<FilterPaintingRequest> FilterPaintingRequestValidator => _filterpaintingvalidator;
    }
}
