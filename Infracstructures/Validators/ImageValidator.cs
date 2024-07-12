using Application.IValidators;
using Application.SendModels.Image;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class ImageValidator : IImageValidator
    {
        private readonly IValidator<ImageRequest> _imagevalidator;

        public ImageValidator(IValidator<ImageRequest> levelvalidator)
        {
            _imagevalidator = levelvalidator;
        }

        public IValidator<ImageRequest> ImageRequestValidator => _imagevalidator;
    }
}
