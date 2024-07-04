using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.BaseModels;
using Application.IService;
using Application.IService.ICommonService;
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
        private readonly IClaimsService _claimsService;
        private readonly IConfiguration _configuration;
        private readonly ICurrentTime _currentTime;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, IConfiguration configuration,
            IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
            _claimsService = claimsService;
        }

        #region Add Report

        public async Task<bool> AddReport(AddReportViewModel addReportViewModel)
        {
            var report = _mapper.Map<Report>(addReportViewModel);
            report.CreatedBy = _claimsService.GetCurrentUserId();
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
            if (report == null) return false;

            report.Status = ReportStatus.Inactive.ToString();

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion

        #region Update Report

        public async Task<bool> UpdateReport(UpdateReportViewModel updateReport)
        {
            var report = await _unitOfWork.ReportRepo.GetByIdAsync(updateReport.Id);
            if (report == null) return false;

            report = _mapper.Map<Report>(updateReport);
            report.UpdatedBy = _claimsService.GetCurrentUserId();
            report.UpdatedTime = _currentTime.GetCurrentTime();


            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion


        #region Get Report By Id

        public async Task<ReportViewModel> GetReportById(Guid reportId)
        {
            return _mapper.Map<ReportViewModel>(await _unitOfWork.AwardRepo.GetByIdAsync(reportId));
        }

        #endregion
    }
}
