using System.Security.Claims;
using Application.IService.ICommonService;
using Microsoft.AspNetCore.Http;

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
        return id == null ? null : Guid.Parse(id);
    }
}