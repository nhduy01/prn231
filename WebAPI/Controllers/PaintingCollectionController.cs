using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.IService;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaintingCollectionController : Controller
    {
        private readonly IPaintingCollectionService _paintingCollectionService;

        public PaintingCollectionController(IPaintingCollectionService paintingCollectionService)
        {
            _paintingCollectionService = paintingCollectionService;
        }
    }
}
