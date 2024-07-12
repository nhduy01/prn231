using Application.IValidators;
using Application.SendModels.Category;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        private readonly IValidator<CategoryRequest> _categoryvalidator;
        private readonly IValidator<UpdateCategoryRequest> _updatecategoryvalidator;

        public CategoryValidator(IValidator<CategoryRequest> categoryvalidator, IValidator<UpdateCategoryRequest> updatecategoryvalidator)
        {
            _categoryvalidator = categoryvalidator;
            _updatecategoryvalidator = updatecategoryvalidator;
        }

        public IValidator<CategoryRequest> CategoryRequestValidator => _categoryvalidator;
        public IValidator<UpdateCategoryRequest> UpdateCategoryRequestValidator => _updatecategoryvalidator;
    }
}
