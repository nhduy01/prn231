using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures.Repositories;

public class AwardRepository : GenericRepository<Award>, IAwardRepository
{
    public AwardRepository(AppDbContext context) : base(context)
    {
    }
}