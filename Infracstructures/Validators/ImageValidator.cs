using Application.IValidators;
using Application.SendModels.Image;
using FluentValidation;

namespace Infracstructures.Validators;

public class ImageValidator : IImageValidator
{
    public ImageValidator(IValidator<ImageRequest> levelvalidator)
    {
        ImageRequestValidator = levelvalidator;
    }

    public IValidator<ImageRequest> ImageRequestValidator { get; }
}