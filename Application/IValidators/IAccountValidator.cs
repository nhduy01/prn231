using Application.ViewModels.AccountViewModels;
using FluentValidation;

namespace Application.IValidators
{
    public interface IAccountValidator
    {
        IValidator<AccountCreateModel> AccountCreateValidator { get; }
        IValidator<AccountUpdateModel> AccountUpdateValidator { get; }

    }
}

