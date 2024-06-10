﻿using Domain.Models;
using Application.IRepositories;
using WebAPI.IService.ICommonService;

namespace Infracstructures.Repositories
{
    public class ResourcesRepository : GenericRepository<Resources>, IResourcesRepository
    {
        public ResourcesRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}