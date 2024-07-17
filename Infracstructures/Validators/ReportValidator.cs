using Application.IValidators;
using Application.SendModels.Report;
using FluentValidation;

namespace Infracstructures.Validators;

public class ReportValidator : IReportValidator
{
    public ReportValidator(IValidator<ReportRequest> reportvalidator,
        IValidator<UpdateReportRequest> updatereportvalidator)
    {
        ReportRequestValidator = reportvalidator;
        UpdateReportRequestValidator = updatereportvalidator;
    }

    public IValidator<ReportRequest> ReportRequestValidator { get; }

    public IValidator<UpdateReportRequest> UpdateReportRequestValidator { get; }
}