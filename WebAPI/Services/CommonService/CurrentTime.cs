using WebAPI.IService.ICommonService;

namespace WebAPI.Services.CommonService
{
    public class CurrentTime : ICurrentTime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}