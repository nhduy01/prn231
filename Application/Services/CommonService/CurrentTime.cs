using WebAPI.IService.ICommonService;

namespace Application.Services.CommonService
{
    public class CurrentTime : ICurrentTime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}