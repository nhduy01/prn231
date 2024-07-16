using Application.SendModels.AccountSendModels;
using Application.SendModels.Authentication;
using Application.ViewModels.AccountViewModels;
using Application.ViewModels.CollectionViewModels;
using Application.ViewModels.ContestViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers;

public partial class MapperConfigs : Profile
{
    partial void AddAccountMapperConfig()
    {
        CreateMap<CreateAccountRequest, Account>();
        CreateMap<AccountUpdateRequest, Account>().ReverseMap();
        CreateMap<Account, AccountViewModel>().ReverseMap();


        CreateMap<Account, AccountInPainting>();

        CreateMap<Account, AccountInContestViewModel>();
    }
}