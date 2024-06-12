using Application.IService;
using Application.IService.ICommonService;
using AutoMapper;
using Infracstructures;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IClaimsService _claimsService;
    private readonly IConfiguration _configuration;
    private readonly ICurrentTime _currentTime;

    // adding mapper in user service using DI
    private readonly IMapper _mapper;
    private readonly ISessionServices _sessionServices;
    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IUnitOfWork unitOfWork, ICurrentTime currentTime,
        IConfiguration configuration, ISessionServices sessionServices,
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