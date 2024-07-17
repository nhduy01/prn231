using Application.SendModels.Category;
using FluentValidation;

namespace Application.IValidators;

public interface ICategoryValidator
{
    IValidator<CategoryRequest> CategoryRequestValidator { get; }
    IValidator<UpdateCategoryRequest> UpdateCategoryRequestValidator { get; }
}