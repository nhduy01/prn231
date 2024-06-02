using Application.IValidators;
using Application.ViewModels.AccountViewModels;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class AccountValidator : IAccountValidator
    {
        private readonly IValidator<AccountCreateModel> _accountCreateValidator;
        private readonly IValidator<AccountUpdateModel> _accountUpdateValidator;

        public AccountValidator(IValidator<AccountUpdateModel> accountUpdateValidator, IValidator<AccountCreateModel> accountCreateValidator)
        {
            _accountCreateValidator = accountCreateValidator;
            _accountUpdateValidator = accountUpdateValidator;
        }

        public IValidator<AccountCreateModel> AccountCreateValidator => _accountCreateValidator;
        public IValidator<AccountUpdateModel> AccountUpdateValidator => _accountUpdateValidator;

    }
}
