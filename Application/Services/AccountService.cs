using Application.Commons;
using Application.Utils;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using Domain.Models;
using Application;
using WebAPI.IService.ICommonService;
using Application.Interfaces;
using Infracstructures;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _currentTime;
        private readonly IConfiguration _configuration;
        private readonly ISessionServices _sessionServices;
        private readonly IClaimsService _claimsService;

        // adding mapper in user service using DI
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, ICurrentTime currentTime,
            IConfiguration configuration,  ISessionServices sessionServices,
            IClaimsService claimsService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _configuration = configuration;
            _sessionServices = sessionServices;
            _claimsService = claimsService;
            _mapper = mapper;
        }

    }
}