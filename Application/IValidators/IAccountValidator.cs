using Application.SendModels.AccountSendModels;
using FluentValidation;

namespace Application.IValidators;

public interface IAccountValidator
{
    IValidator<AccountUpdateRequest> AccountUpdateRequestValidator { get; }
    IValidator<SubAccountRequest> SubAccountRequestValidator { get; }
}