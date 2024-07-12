using Application.SendModels.AccountSendModels;
using Application.SendModels.Post;
using FluentValidation;

namespace WebAPI.Validation.PostValidation
{
    public class UpdatePostValidator : AbstractValidator<PostUpdateRequest>

    {
    }
}
