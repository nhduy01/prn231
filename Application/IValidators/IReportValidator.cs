using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.Report;
using FluentValidation;

namespace Application.IValidators
{
    public interface IReportValidator
    {
        IValidator<ReportRequest> ReportRequestValidator { get; }
        IValidator<UpdateReportRequest> UpdateReportRequestValidator { get; }
    }
}
