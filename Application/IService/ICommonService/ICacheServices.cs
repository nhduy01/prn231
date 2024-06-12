namespace Application.IService.ICommonService;

public interface ICacheServices
{
    Task Set(string key, object value, int time);

    Task<T> Get<T>(string key);

    Task Remove(string key);
}