using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/awardschedules/")]
public class AwardScheduleController : Controller
{
    private readonly IAwardScheduleService _awardSchedule;

    public AwardScheduleController(IAwardScheduleService awardSchedule)
    {
        _awardSchedule = awardSchedule;
    }
}