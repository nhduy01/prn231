using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using WebAPI.IService.ICommonService;

public class ClaimsService : IClaimsService
{
    private readonly IHttpContextAccessor _contextAccessor;
    public ClaimsService(IHttpContextAccessor httpContextAccessor)
    {
        _contextAccessor = httpContextAccessor;
    }
    public Guid? GetCurrentUserId()
    {
        var id = _contextAccessor.HttpContext?.User.FindFirstValue("AccountId");
        return id == null ? (Guid?)null : Guid.Parse(id);
    }
}