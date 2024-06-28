using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService.ICommonService;
using Application.IService;
using AutoMapper;
using Infracstructures;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IClaimsService _claimsService;
        private readonly IConfiguration _configuration;
        private readonly ICurrentTime _currentTime;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime,
            IConfiguration configuration, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
            _claimsService = claimsService;
        }
    }


}
