using Application.IValidators;
using Application.SendModels.Post;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class PostValidator : IPostValidator
    {
        private readonly IValidator<PostRequest> _postvalidator;
        private readonly IValidator<PostUpdateRequest> _updatepostvalidator;

        public PostValidator(IValidator<PostRequest> postvalidator, IValidator<PostUpdateRequest> updatepostvalidator)
        {
            _postvalidator = postvalidator;
            _updatepostvalidator = updatepostvalidator;
        }

        public IValidator<PostRequest> PostRequestValidator => _postvalidator;
        public IValidator<PostUpdateRequest> UpdatePostValidator => _updatepostvalidator;
    }
}
