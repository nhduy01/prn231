using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Schedule;
using FluentValidation;

namespace Application.IValidators
{
    public interface IScheduleValidator
    {
        IValidator<ScheduleRequest> ScheduleRequestValidator {  get; }
        IValidator<ScheduleUpdateRequest> ScheduleUpdateRequestValidator { get; }
        IValidator<ScheduleForFinalRequest> ScheduleForFinalRequestValidator { get; }
    }
}
