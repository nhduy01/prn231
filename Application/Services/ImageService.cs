using Application.BaseModels;
using Application.IService;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Infracstructures.SendModels.Image;
using Infracstructures.ViewModels.ImageViewModels;

namespace Application.Services;

public class ImageService : IImageService
{
        private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public ImageService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Create

    public async Task<Guid?> CreateImage(ImageRequest Image)
    {
        var newImage = _mapper.Map<Image>(Image);
        newImage.Status = ImageStatus.ACTIVE.ToString();
        await _unitOfWork.ImageRepo.AddAsync(newImage);
        await _unitOfWork.SaveChangesAsync();
        return newImage.Id;
    }

    #endregion

    #region Get All

    public async Task<(List<ImageViewModel>, int)> GetListImage(ListModels listModels)
    {
        var list = await _unitOfWork.ImageRepo.GetAllAsync();
        list = (List<Image>)list.Where(x => x.Status == "ACTIVE");

        var result = new List<Image>();

        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<ImageViewModel>>(result), totalPages);
    }

    #endregion

    #region Get By Id

    public async Task<ImageViewModel?> GetImageById(Guid id)
    {
        var Image = await _unitOfWork.ImageRepo.GetByIdAsync(id);
        if (Image == null) return null;
        return _mapper.Map<ImageViewModel>(Image);
    }

    #endregion
    

    #region Delete

    public async Task<bool?> DeleteImage(Guid id)
    {
        var Image = await _unitOfWork.ImageRepo.GetByIdAsync(id);
        if (Image == null) return false;

        Image.Status = "INACTIVE";
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    #endregion
}