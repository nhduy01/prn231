using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.AccountSendModels;
using Application.SendModels.Image;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class AccountValidator : IAccountValidator 
    {
        private readonly IValidator<AccountUpdateRequest> _accountvalidator;
        private readonly IValidator<SubAccountRequest> _subaccountvalidator;

        public AccountValidator(IValidator<AccountUpdateRequest> accountvalidator, IValidator<SubAccountRequest> subaccountvalidator)
        {
            _accountvalidator = accountvalidator;
            _subaccountvalidator = subaccountvalidator;
        }

        public IValidator<AccountUpdateRequest> AccountUpdateRequestValidator => _accountvalidator;
        public IValidator<SubAccountRequest> SubAccountRequestValidator => _subaccountvalidator;
    }
}
