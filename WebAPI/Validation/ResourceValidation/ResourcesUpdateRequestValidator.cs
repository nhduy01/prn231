﻿using Application.IService;
using Application.IService.IValidationService;
using Application.SendModels.Resources;
using FluentValidation;

namespace WebAPI.Validation.ResourceValidation;

public class ResourcesUpdateRequestValidator : AbstractValidator<ResourcesUpdateRequest>
{
    private readonly IAccountValidationService _accountValidationService;
    private readonly IResourceValidationService _resourceValidationService;

    public ResourcesUpdateRequestValidator(IAccountValidationService accountValidationService, IResourceValidationService resourceValidationService)
    {
        _accountValidationService = accountValidationService;
        _resourceValidationService = resourceValidationService;
        // Validate Id
        RuleFor(x => x.Id)
        .NotEmpty().WithMessage("Id không được để trống.");

        When(x => !string.IsNullOrEmpty(x.Id.ToString()), () =>
        {
            RuleFor(x => x.Id)
                .Must(topicId => Guid.TryParse(topicId.ToString(), out _))
                .WithMessage("Id phải là một GUID hợp lệ.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .MustAsync(async (topicId, cancellation) =>
                        {
                            try
                            {
                                return await _resourceValidationService.IsExistedId(topicId);
                            }
                            catch (Exception)
                            {
                                // Xử lý lỗi kiểm tra ID
                                return false; // Giả sử ID không tồn tại khi có lỗi
                            }
                        })
                        .WithMessage("Id không tồn tại.");
                });
        });

        // Validate Sponsorship
        RuleFor(x => x.Sponsorship)
            .MaximumLength(200).WithMessage("Sponsorship phải có ít hơn 200 chữ.");

        // Validate CurrentUserId
        RuleFor(x => x.CurrentUserId)
        .NotEmpty().WithMessage("CurrentUserId không được để trống.");

        When(x => !string.IsNullOrEmpty(x.CurrentUserId.ToString()), () =>
        {
            RuleFor(x => x.CurrentUserId)
                .Must(userId => Guid.TryParse(userId.ToString(), out _))
                .WithMessage("CurrentUserId phải là một GUID hợp lệ.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.CurrentUserId)
                        .MustAsync(async (userId, cancellation) =>
                        {
                            try
                            {
                                return await _accountValidationService.IsExistedId(userId);
                            }
                            catch (Exception)
                            {
                                // Xử lý lỗi kiểm tra ID
                                return false; // Giả sử ID không tồn tại khi có lỗi
                            }
                        })
                        .WithMessage("CurrentUserId không tồn tại.");
                });
        });
    }
}