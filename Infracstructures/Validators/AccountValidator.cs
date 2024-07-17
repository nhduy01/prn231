using Application.IValidators;
using Application.SendModels.AccountSendModels;
using FluentValidation;

namespace Infracstructures.Validators;

public class AccountValidator : IAccountValidator
{
    public AccountValidator(IValidator<AccountUpdateRequest> accountvalidator,
        IValidator<SubAccountRequest> subaccountvalidator)
    {
        AccountUpdateRequestValidator = accountvalidator;
        SubAccountRequestValidator = subaccountvalidator;
    }

    public IValidator<AccountUpdateRequest> AccountUpdateRequestValidator { get; }

    public IValidator<SubAccountRequest> SubAccountRequestValidator { get; }
}