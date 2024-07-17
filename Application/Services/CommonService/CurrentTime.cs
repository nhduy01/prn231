using Application.IService.ICommonService;
using TimeZoneConverter;

namespace Application.Services.CommonService;

public class CurrentTime : ICurrentTime
{
    public DateTime GetCurrentTime()
    {
        var vietnamTimeZone = TZConvert.GetTimeZoneInfo("SE Asia Standard Time");

        var currentTimeInVietnam = TimeZoneInfo.ConvertTime(DateTime.UtcNow, vietnamTimeZone);

        return currentTimeInVietnam;
    }
}