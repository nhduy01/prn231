using Application.BaseModels;
using Application.SendModels.AccountSendModels;
using Application.ViewModels.AccountViewModels;

namespace Application.IService;

public interface IAccountService
{
    public Task<bool?> CreateSubAccount(SubAccountRequest request);
    public Task<(List<AccountViewModel>, int)> GetListExaminer(ListModels listModels);
    public Task<(List<AccountViewModel>, int)> GetListCompetitor(ListModels listModels);
    Task<(List<AccountViewModel>, int)> GetListStaff(ListModels listModels);
    Task<(List<AccountViewModel>, int)> GetListInactiveAccount(ListModels listModels);
    public Task<AccountViewModel?> GetAccountById(Guid id);
    public Task<bool?> UpdateAccount(AccountUpdateRequest updateAccount);
    public Task<bool?> InactiveAccount(Guid id);
    Task<bool?> ActiveAccount(Guid id);

    Task<List<AccountViewModel>> ListAccountHaveAwardIn3NearestContest();

    Task<AccountViewModel?> GetAccountByCode(string code);
    Task<bool> IsExistedId(Guid id);
}