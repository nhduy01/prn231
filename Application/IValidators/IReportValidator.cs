using Application.SendModels.Report;
using FluentValidation;

namespace Application.IValidators;

public interface IReportValidator
{
    IValidator<ReportRequest> ReportRequestValidator { get; }
    IValidator<UpdateReportRequest> UpdateReportRequestValidator { get; }
}