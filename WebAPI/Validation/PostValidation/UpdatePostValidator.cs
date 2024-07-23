using Application.SendModels.Post;
using FluentValidation;
using WebAPI.Validation.ImageValidation;

namespace WebAPI.Validation.PostValidation;

public class UpdatePostValidator : AbstractValidator<PostUpdateRequest>
{
    public UpdatePostValidator()
    {
        // Validate Id
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .NotEqual(Guid.Empty).WithMessage("Id must be a valid GUID.");

        // Validate Url
        RuleFor(x => x.Url)
            .Must(BeAValidUrl).WithMessage("Url must be a valid URL and use HTTP or HTTPS.");

        // Validate CategoryId
        RuleFor(x => x.CategoryId)
            .NotEqual(Guid.Empty).When(x => x.CategoryId.HasValue).WithMessage("CategoryId must be a valid GUID.");

        // Validate CurrentUserId
        RuleFor(x => x.CurrentUserId)
            .NotEmpty().WithMessage("CurrentUserId is required.")
            .NotEqual(Guid.Empty).WithMessage("CurrentUserId must be a valid GUID.");

        // Validate DeleteImages
        RuleFor(x => x.DeleteImages)
            .NotNull().WithMessage("DeleteImages list cannot be null.")
            .Must(images => images == null || images.All(image => image != Guid.Empty)).WithMessage("Each image GUID in DeleteImages must be a valid GUID.");

        // Validate NewImages
        RuleFor(x => x.NewImages)
            .NotNull().WithMessage("NewImages list cannot be null.")
            .Must(images => images == null || images.Any()).WithMessage("NewImages list must contain at least one item.")
            .ForEach(image => image
                .SetValidator(new ImageRequestValidator())); // Assuming you have an ImageRequestValidator for validating individual images
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}