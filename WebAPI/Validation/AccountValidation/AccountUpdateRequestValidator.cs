using Application.SendModels.AccountSendModels;
using FluentValidation;

namespace WebAPI.Validation.AccountValidation
{
    public class AccountUpdateRequestValidator : AbstractValidator<AccountUpdateRequest>
    {
        public AccountUpdateRequestValidator()
        {
            RuleFor(user => user.Id).NotEmpty().WithMessage("Id không được để trống.");

            RuleFor(user => user.Birthday)
                .NotEmpty().WithMessage("Ngày sinh không được để trống.")
                .Must(BeAValidAge).WithMessage("Ngày sinh không hợp lệ.");

            RuleFor(user => user.FullName)
                .NotEmpty().WithMessage("Tên đầy đủ không được để trống.")
                .Length(2, 100).WithMessage("Tên đầy đủ phải có độ dài từ 2 đến 100 ký tự.");

            RuleFor(user => user.Address)
                .NotEmpty().WithMessage("Địa chỉ không được để trống.")
                .Length(10, 200).WithMessage("Địa chỉ phải có độ dài từ 10 đến 200 ký tự.");

            RuleFor(user => user.Phone)
                .NotEmpty().WithMessage("Số điện thoại không được để trống.")
                .Matches(@"^\d{10,15}$").WithMessage("Số điện thoại không hợp lệ.");

            RuleFor(user => user.Avatar)
                .Must(BeAValidUrl).When(user => !string.IsNullOrEmpty(user.Avatar)).WithMessage("Avatar phải là một URL hợp lệ.");
        }

        private bool BeAValidAge(DateTime birthday)
        {
            var age = DateTime.Today.Year - birthday.Year;
            if (birthday.Date > DateTime.Today.AddYears(-age)) age--;
            return age >= 0 && age <= 120; // Giới hạn tuổi từ 0 đến 120
        }

        private bool BeAValidUrl(string? avatar)
        {
            if (string.IsNullOrEmpty(avatar)) return true;
            return Uri.TryCreate(avatar, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
