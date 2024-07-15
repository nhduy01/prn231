using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Round;
using FluentValidation;

namespace Application.IValidators
{
    public interface IRoundValidator
    {
        IValidator<RoundRequest> RoundRequestValidator { get; }
        IValidator<RoundUpdateRequest> RoundUpdateRequestValidator { get; }
    }
}
