using Application.SendModels.Image;
using FluentValidation;

namespace WebAPI.Validation.ImageValidation;

public class ImageRequestValidator : AbstractValidator<ImageRequest>
{
    public ImageRequestValidator()
    {
        // Validate Url
        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Url is required.")
            .Must(BeAValidUrl).WithMessage("Url must be a valid URL and use HTTP or HTTPS.");

        // Validate Description (optional)
        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description must be less than 250 characters.");
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}