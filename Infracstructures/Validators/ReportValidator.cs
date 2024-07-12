using Application.IValidators;
using Application.SendModels.Report;
using FluentValidation;

namespace Infracstructures.Validators
{
    public class ReportValidator : IReportValidator
    {
        private readonly IValidator<ReportRequest> _reportvalidator;
        private readonly IValidator<UpdateReportRequest> _updatereportvalidator;

        public ReportValidator(IValidator<ReportRequest> reportvalidator, IValidator<UpdateReportRequest> updatereportvalidator)
        {
            _reportvalidator = reportvalidator;
            _updatereportvalidator = updatereportvalidator;
        }

        public IValidator<ReportRequest> ReportRequestValidator => _reportvalidator;
        public IValidator<UpdateReportRequest> UpdateReportRequestValidator => _updatereportvalidator;
    }
}
