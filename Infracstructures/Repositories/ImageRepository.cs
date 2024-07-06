using Application.IRepositories;
using Domain.Enums;
using Domain.Models;

namespace Infracstructures.Repositories;

public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    public ImageRepository(AppDbContext context) : base(context)
    {
    }
        
}
