using Application.SendModels.Post;
using FluentValidation;

namespace Application.IValidators;

public interface IPostValidator
{
    IValidator<PostRequest> PostRequestValidator { get; }
    IValidator<PostUpdateRequest> UpdatePostValidator { get; }
}