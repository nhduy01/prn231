using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.IService;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EducationalLevelController : Controller
    {
        private readonly IEducationalLevelService _educationalLevelService;

        public EducationalLevelController(IEducationalLevelService educationalLevelService)
        {
            _educationalLevelService = educationalLevelService;
        }
    }
}
