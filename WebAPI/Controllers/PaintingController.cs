using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.IService;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaintingController : Controller
    {
        private readonly IPaintingService _paintingService;

        public PaintingController(IPaintingService paintingService)
        {
            _paintingService = paintingService;
        }
    }
}
