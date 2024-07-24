﻿using Application.IService;
using Application.IService.IValidationService;
using Application.SendModels.Post;
using FluentValidation;
using WebAPI.Validation.ImageValidation;

namespace WebAPI.Validation.PostValidation;

public class UpdatePostValidator : AbstractValidator<PostUpdateRequest>
{
    private readonly IAccountValidationService _accountValidationService;
    private readonly IPostValidationService _postValidationService;

    public UpdatePostValidator(IAccountValidationService accountValidationService, IPostValidationService postValidationService)
    {
        _accountValidationService = accountValidationService;
        _postValidationService = postValidationService;
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
                                return await _postValidationService.IsExistedId(topicId);
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
        // Validate Url
        RuleFor(x => x.Url)
            .Must(BeAValidUrl).WithMessage("Url phải là một URL hợp lệ và sử dụng HTTP hoặc HTTPS.");

        // Validate CategoryId
        RuleFor(x => x.CategoryId)
            .NotEqual(Guid.Empty).When(x => x.CategoryId.HasValue).WithMessage("CategoryId phải là một GUID hợp lệ.");

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

        // Validate DeleteImages
        RuleFor(x => x.DeleteImages)
            .NotNull().WithMessage("Danh sách DeleteImages không được để null.")
            .Must(images => images == null || images.All(image => image != Guid.Empty)).WithMessage("Mỗi GUID trong DeleteImages phải là một GUID hợp lệ.");

        // Validate NewImages
        RuleFor(x => x.NewImages)
            .NotNull().WithMessage("Danh sách NewImages không được để null.")
            .Must(images => images == null || images.Any()).WithMessage("Danh sách NewImages phải chứa ít nhất một mục.")
            .ForEach(image => image
                .SetValidator(new ImageRequestValidator())); // Giả định rằng bạn có một ImageRequestValidator để kiểm tra từng hình ảnh
    }

    private bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}