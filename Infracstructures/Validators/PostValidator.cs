using Application.IValidators;
using Application.SendModels.Post;
using FluentValidation;

namespace Infracstructures.Validators;

public class PostValidator : IPostValidator
{
    public PostValidator(IValidator<PostRequest> postvalidator, IValidator<PostUpdateRequest> updatepostvalidator)
    {
        PostRequestValidator = postvalidator;
        UpdatePostValidator = updatepostvalidator;
    }

    public IValidator<PostRequest> PostRequestValidator { get; }

    public IValidator<PostUpdateRequest> UpdatePostValidator { get; }
}