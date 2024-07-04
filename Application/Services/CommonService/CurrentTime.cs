using Application.IService.ICommonService;
using TimeZoneConverter;

namespace Application.Services.CommonService;

public class CurrentTime : ICurrentTime
{
    public DateTime GetCurrentTime()
    {
        TimeZoneInfo vietnamTimeZone = TZConvert.GetTimeZoneInfo("SE Asia Standard Time");

        DateTime currentTimeInVietnam = TimeZoneInfo.ConvertTime(DateTime.UtcNow, vietnamTimeZone);

        return currentTimeInVietnam;
    }
}