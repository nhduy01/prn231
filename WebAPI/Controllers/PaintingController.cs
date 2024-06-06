using Application.IService;
using Microsoft.AspNetCore.Mvc;

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
