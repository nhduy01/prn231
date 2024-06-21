using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/paintingcollections/")]
public class PaintingCollectionController : Controller
{
    private readonly IPaintingCollectionService _paintingCollectionService;

    public PaintingCollectionController(IPaintingCollectionService paintingCollectionService)
    {
        _paintingCollectionService = paintingCollectionService;
    }
}