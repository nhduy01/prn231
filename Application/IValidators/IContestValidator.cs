using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Contest;
using FluentValidation;

namespace Application.IValidators
{
    public interface IContestValidator
    {
        IValidator<ContestRequest> ContestRequestValidator { get; }
        IValidator<UpdateContest> UpdateContestValidator { get; }
    }
}
