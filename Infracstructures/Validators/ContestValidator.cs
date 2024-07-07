using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IValidators;
using Application.SendModels.Collection;
using Application.SendModels.Contest;
using Domain.Models;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class ContestValidator : IContestValidator
    {
        private readonly IValidator<ContestRequest> _contestvalidator;
        private readonly IValidator<UpdateContest> _updatecontestvalidator;

        public ContestValidator(IValidator<ContestRequest> contestvalidator, IValidator<UpdateContest> updatecontestvalidator)
        {
            _contestvalidator = contestvalidator;
            _updatecontestvalidator = updatecontestvalidator;
        }

        public IValidator<ContestRequest> AwardCreateValidator => _contestvalidator;
        public IValidator<UpdateContest> UserAwardValidator => _updatecontestvalidator;
    }
}
