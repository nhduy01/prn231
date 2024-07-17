using Application.SendModels.Image;
using FluentValidation;

namespace Application.IValidators;

public interface IImageValidator
{
    IValidator<ImageRequest> ImageRequestValidator { get; }
}