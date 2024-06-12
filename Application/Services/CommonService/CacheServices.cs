using Application.IService.ICommonService;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services.CommonService;

public class CacheServices : ICacheServices
{
    private readonly IMemoryCache _cache;

    public CacheServices(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task Set(string key, object value, int time)
    {
        _cache.Set(key, value, TimeSpan.FromMinutes(time));
    }

    public async Task<T> Get<T>(string key)
    {
        return _cache.Get<T>(key);
    }

    public async Task Remove(string key)
    {
        _cache.Remove(key);
    }
}