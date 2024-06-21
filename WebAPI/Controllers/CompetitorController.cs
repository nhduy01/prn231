using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/competitors/")]
public class CompetitorController : Controller
{
    private readonly ICompetitorService _competitorService;

    public CompetitorController(ICompetitorService competitorService)
    {
        _competitorService = competitorService;
    }
}