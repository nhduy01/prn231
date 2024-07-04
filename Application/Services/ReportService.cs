using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.BaseModels;
using Application.IService;
using Application.IService.ICommonService;
using Application.SendModels.Report;
using Application.ViewModels.AwardViewModels;
using Application.ViewModels.ReportViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IConfiguration _configuration;
        private readonly ICurrentTime _currentTime;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
        }

        #region Add Report

        public async Task<bool> AddReport(ReportRequest addReportViewModel)
        {
            var report = _mapper.Map<Report>(addReportViewModel);
            report.Status = ReportStatus.Pending.ToString();
            await _unitOfWork.ReportRepo.AddAsync(report);

            return await _unitOfWork.SaveChangesAsync() > 0;

        }

        #endregion

        #region Get All Report

        public async Task<(List<ReportViewModel>, int)> GetAllReportPending(ListModels listAwardModel)
        {
            var reportList = await _unitOfWork.ReportRepo.GetAllAsync();
            reportList = reportList.Where(x => x.Status == ReportStatus.Pending.ToString()).ToList();
            var result = _mapper.Map<List<ReportViewModel>>(reportList);

            var totalPages = (int)Math.Ceiling((double)result.Count / listAwardModel.PageSize);
            int? itemsToSkip = (listAwardModel.PageNumber - 1) * listAwardModel.PageSize;
            result = result.Skip((int)itemsToSkip)
                .Take(listAwardModel.PageSize)
                .ToList();
            return (result, totalPages);
        }

        #endregion

        #region Delete Report

        public async Task<bool> DeleteReport(Guid reportId)
        {
            var report = await _unitOfWork.ReportRepo.GetByIdAsync(reportId);
            if (report == null) throw new Exception("Khong tim thay Report");

            report.Status = ReportStatus.Inactive.ToString();

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion

        #region Update Report

        public async Task<bool> UpdateReport(UpdateReportRequest updateReport)
        {
            var report = await _unitOfWork.ReportRepo.GetByIdAsync(updateReport.Id);
            if (report == null) throw new Exception("Khong tim thay Report");

            _mapper.Map(updateReport, report);
            report.UpdatedTime = _currentTime.GetCurrentTime();


            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion


        #region Get Report By Id

        public async Task<ReportViewModel> GetReportById(Guid reportId)
        {
            var result = await _unitOfWork.ReportRepo.GetByIdAsync(reportId);
            return _mapper.Map<ReportViewModel>(result);
        }

        #endregion
    }
}
