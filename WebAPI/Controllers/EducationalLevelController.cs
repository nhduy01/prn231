﻿using Application.IService;
using Microsoft.AspNetCore.Mvc;

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