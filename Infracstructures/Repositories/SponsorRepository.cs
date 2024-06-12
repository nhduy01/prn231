using Application.IRepositories;
using Domain.Models;

namespace Infracstructures.Repositories;

public class SponsorRepository : GenericRepository<Sponsor>, ISponsorRepository
{
    public SponsorRepository(AppDbContext context) : base(context)
    {
    }
}