using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Category;
using FluentValidation;

namespace Application.IValidators
{
    public interface ICategoryValidator
    {
        IValidator<CategoryRequest> CategoryRequestValidator { get; }
        IValidator<UpdateCategoryRequest> UpdateCategoryRequestValidator { get; }
    }
}
