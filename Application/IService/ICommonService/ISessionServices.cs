namespace Application.IService.ICommonService;

public interface ISessionServices
{
    void SaveToken(int id, string token);
    string GetTokenByKey(int id);
    bool RemoveToken(int id);
}