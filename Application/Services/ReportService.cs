using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService;
using AutoMapper;
using Infracstructures;

namespace Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
        {
            _imageService = imageService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
