using Application.BaseModels;
using Infracstructures.SendModels.Image;
using Infracstructures.ViewModels.ImageViewModels;

namespace Application.IService;

public interface IImageService
{
    public Task<Guid?> CreateImage(ImageRequest Image);
    public Task<(List<ImageViewModel>, int)> GetListImage(ListModels listModels);
    public Task<ImageViewModel?> GetImageById(Guid id);
    public Task<bool?> DeleteImage(Guid id);
}