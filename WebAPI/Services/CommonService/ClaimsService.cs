using System.Security.Claims;
using WebAPI.IService.ICommonService;

public class ClaimsService : IClaimsService
{
    private readonly IHttpContextAccessor _contextAccessor;
    public ClaimsService(IHttpContextAccessor httpContextAccessor)
    {
        if (httpContextAccessor.HttpContext != null)
        {
            var id = httpContextAccessor.HttpContext.User.FindFirstValue("AccountId");
            GetCurrentUserId = id == null ? -1 : int.Parse(id);
        }
    }
    public int GetCurrentUserId { get; }
}