using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.Award;
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

        public IValidator<CategoryRequest> AwardCreateValidator => _categoryvalidator;
        public IValidator<UpdateCategoryRequest> UserAwardValidator => _updatecategoryvalidator;
    }
}
