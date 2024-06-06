using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.IService;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostImageController : Controller
    {
        private readonly IPostImageService _postImageService;

        public PostImageController(IPostImageService postImageService)
        {
            _postImageService = postImageService;
        }
    }
}
