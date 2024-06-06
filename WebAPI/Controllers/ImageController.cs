using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.IService;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
    }
}
