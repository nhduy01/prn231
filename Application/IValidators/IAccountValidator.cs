using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.AccountSendModels;
using FluentValidation;

namespace Application.IValidators
{
    public interface IAccountValidator
    {
        IValidator<AccountUpdateRequest> AccountUpdateRequestValidator { get; }
        IValidator<SubAccountRequest> SubAccountRequestValidator { get; }
    }
}
