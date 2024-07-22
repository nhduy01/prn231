using Application.SendModels.Post;
using FluentValidation;
using WebAPI.Validation.ImageValidation;

namespace WebAPI.Validation.PostValidation;

public class PostRequestValidator : AbstractValidator<PostRequest>
{
    public PostRequestValidator()
    {
        // Validate Url
        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Url is required.")
            .Must(BeAValidUrl).WithMessage("Url must be a valid URL and use HTTP or HTTPS.");

        // Validate Title
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must be less than 100 characters.");

        // Validate Description
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must be less than 500 characters.");

        // Validate CategoryId
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required.")
            .NotEqual(Guid.Empty).WithMessage("CategoryId must be a valid GUID.");

        // Validate Images
        RuleFor(x => x.Images)
            .NotNull().WithMessage("Images list cannot be null.")
            .Must(images => images != null && images.Any()).WithMessage("Images list must contain at least one item.")
            .ForEach(image => image
                .SetValidator(new ImageRequestValidator())); // Assuming you have an ImageRequestValidator for validating individual images

        // Validate CurrentUserId
        RuleFor(x => x.CurrentUserId)
            .NotEmpty().WithMessage("CurrentUserId is required.")
            .NotEqual(Guid.Empty).WithMessage("CurrentUserId must be a valid GUID.");
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}