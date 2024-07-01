using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.BaseModels;
using Application.ViewModels.ReportViewModels;

namespace Application.IService
{
    public interface IReportService
    {
        Task<bool> AddReport(AddReportViewModel addReportViewModel);
        Task<(List<ReportViewModel>, int)> GetAllReportPending(ListModels listAwardModel);
        Task<bool> DeleteReport(Guid reportId);
        Task<bool> UpdateReport(UpdateReportViewModel updateReport);
        Task<ReportViewModel> GetReportById(Guid reportId);
    }
}
