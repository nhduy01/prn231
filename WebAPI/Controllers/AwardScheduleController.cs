using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.IService;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AwardScheduleController : Controller
    {
        private readonly IAwardScheduleService _awardSchedule;

        public AwardScheduleController(IAwardScheduleService awardSchedule)
        {
            _awardSchedule = awardSchedule;
        }
    }
}
