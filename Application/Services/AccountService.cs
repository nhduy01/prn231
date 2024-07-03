using Application.BaseModels;
using Application.IService;
using Application.IService.ICommonService;
using Application.SendModels.AccountSendModels;
using Application.ViewModels.AccountViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
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

    public Task<bool?> CreateSubAccount(SubAccountRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<(List<AccountViewModel>, int)> GetListExaminer(ListModels listModels)
    {
        var accountList = await _unitOfWork.AccountRepo.GetAllAsync();
        accountList = (List<Account>)accountList.Where(x => x.Status == "ACTIVE" && x.Role == Role.Examiner.ToString());
        var result = _mapper.Map<List<AccountViewModel>>(accountList);

        var totalPages = (int)Math.Ceiling((double)result.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (result, totalPages);
    }
    
    public async Task<(List<AccountViewModel>, int)> GetListCompetitor(ListModels listModels)
    {
        var accountList = await _unitOfWork.AccountRepo.GetAllAsync();
        accountList = (List<Account>)accountList.Where(x => x.Status == "ACTIVE" && x.Role == Role.Competitor.ToString());
        var result = _mapper.Map<List<AccountViewModel>>(accountList);

        var totalPages = (int)Math.Ceiling((double)result.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (result, totalPages);
    }
    
    public async Task<AccountViewModel?> GetAccountById(Guid id)
    {
        var account = await _unitOfWork.AccountRepo.GetByIdAsync(id);
        if (account == null || account.Status == AccountStatus.Inactive.ToString())
        {
            return null;
        }
        return _mapper.Map<AccountViewModel>(account);
    }

    public Task<AccountViewModel?> UpdateAccount(AccountUpdateRequest updateAccount)
    {
        throw new NotImplementedException();
    }

    public Task<bool?> DeleteAccount(Guid id)
    {
        throw new NotImplementedException();
    }
}