﻿using Application.SendModels.Category;
using FluentValidation;

namespace WebAPI.Validation.CategoryValidation;

public class CategoryRequestValidator : AbstractValidator<CategoryRequest>
{
    public CategoryRequestValidator()
    {
        RuleFor(c => c.CurrentUserId)
            .NotEmpty().WithMessage("CurrentUserId không được để trống.")
            .NotEqual(Guid.Empty).WithMessage("CurrentUserId không được là Guid.Empty.");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Tên không được để trống.")
            .Length(2, 50).WithMessage("Tên phải có độ dài từ 2 đến 50 ký tự.");
    }
}