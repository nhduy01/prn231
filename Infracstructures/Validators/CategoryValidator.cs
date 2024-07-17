using Application.IValidators;
using Application.SendModels.Category;
using FluentValidation;

namespace Infracstructures.Validators;

public class CategoryValidator : ICategoryValidator
{
    public CategoryValidator(IValidator<CategoryRequest> categoryvalidator,
        IValidator<UpdateCategoryRequest> updatecategoryvalidator)
    {
        CategoryRequestValidator = categoryvalidator;
        UpdateCategoryRequestValidator = updatecategoryvalidator;
    }

    public IValidator<CategoryRequest> CategoryRequestValidator { get; }

    public IValidator<UpdateCategoryRequest> UpdateCategoryRequestValidator { get; }
}